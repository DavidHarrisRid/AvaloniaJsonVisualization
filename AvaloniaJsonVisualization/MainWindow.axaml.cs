using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
namespace AvaloniaJsonVisualization;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void JsonInputResizeThumb_OnDragDelta(object? sender, VectorEventArgs e)
    {
        ResizeBox(JsonInputBox, e.Vector.Y);
    }

    private void JsonTreeResizeThumb_OnDragDelta(object? sender, VectorEventArgs e)
    {
        ResizeBox(JsonTreeBox, e.Vector.Y);
    }

    private void ScriptInputResizeThumb_OnDragDelta(object? sender, VectorEventArgs e)
    {
        ResizeBox(ScriptInputBox, e.Vector.Y);
    }

    private void WebPreviewResizeThumb_OnDragDelta(object? sender, VectorEventArgs e)
    {
        ResizeBox(WebPreviewBox, e.Vector.Y);
    }

    private static void ResizeBox(Control box, double deltaY)
    {
        var currentHeight = double.IsNaN(box.Height) ? box.Bounds.Height : box.Height;
        var newHeight = Math.Max(box.MinHeight, currentHeight + deltaY);

        box.Height = newHeight;
    }

    // Wird ausgelöst, sobald sich JSON-Input oder Script-Input ändert.
    private void Input_OnTextChanged(object? sender, TextChangedEventArgs e)
    {
        RunPipeline();
    }

    private void RunPipeline()
    {
        // Rohes JSON aus dem Eingabefeld.
        var json = JsonInput.Text ?? "";

        // JavaScript-Visualizer-Code aus dem Script-Feld.
        var script = ScriptInput.Text ?? "";

        try
        {
            // JSON wird geparst, damit C# daraus die TreeView bauen kann.
            using var document = JsonDocument.Parse(json);

            // Die JSON-Struktur wird direkt als TreeView angezeigt.
            JsonTree.ItemsSource = ToTree(document.RootElement);

            // Das gleiche JSON wird als String an die WebView/JavaScript-Pipeline weitergegeben.
            ShowInWebView(BuildHtml(document.RootElement.GetRawText(), script));

            StatusText.Text = "JSON valid. TreeView and WebView updated.";
        }
        catch (Exception ex)
        {
            // Bei ungültigem JSON oder Fehlern wird die Anzeige zurückgesetzt.
            JsonTree.ItemsSource = null;
            StatusText.Text = "Error: " + ex.Message;

            ShowInWebView("<h2 style='font-family:Arial;color:red;padding:20px;'>Invalid JSON or script error.</h2>");
        }
    }

    private static IEnumerable<TreeViewItem> ToTree(JsonElement element)
    {
        // Wandelt ein JSON-Objekt, Array oder Einzelwert in TreeViewItems um.
        return element.ValueKind switch
        {
            // JSON-Objekt: Jede Property wird ein TreeView-Eintrag.
            JsonValueKind.Object => element
                .EnumerateObject()
                .Select(property => ToItem(property.Name, property.Value)),

            // JSON-Array: Jeder Eintrag wird mit Index angezeigt.
            JsonValueKind.Array => element
                .EnumerateArray()
                .Select((item, index) => ToItem($"[{index}]", item)),

            // Einzelwert: Wird als einfacher value-Knoten angezeigt.
            _ => new[] { ToItem("value", element) }
        };
    }

    private static TreeViewItem ToItem(string name, JsonElement element)
    {
        // Objekte und Arrays können Unterelemente haben.
        var hasChildren =
            element.ValueKind == JsonValueKind.Object ||
            element.ValueKind == JsonValueKind.Array;

        // Für Objekte/Arrays wird nur der Name angezeigt.
        // Für Einzelwerte wird Name + Wert angezeigt.
        return new TreeViewItem
        {
            Header = hasChildren ? name : $"{name}: {element.GetRawText()}",
            ItemsSource = hasChildren ? ToTree(element) : null
        };
    }

    private static string BuildHtml(string json, string script)
    {
        // JSON wird als sicherer JavaScript-String vorbereitet.
        var jsonString = JsonSerializer.Serialize(json);

        // Verhindert, dass ein </script> im User-Script den HTML-Script-Block kaputt macht.
        script = script.Replace("</script>", "<\\/script>");

        // Minimaler HTML-Rahmen für die WebView.
        // Stellt data, app und h(value) für das User-Script bereit.
        return $$"""
        <!doctype html>
        <meta charset="utf-8">

        <div id="app"></div>

        <script>
            // JSON aus C# kommt als String in JavaScript an.
            const rawJson = {{jsonString}};

            // Daraus wird das JavaScript-Objekt data.
            const data = JSON.parse(rawJson);

            // app ist die Ausgabefläche in der WebView.
            const app = document.getElementById("app");

            // Hilfsfunktion zum sicheren Einfügen von JSON-Werten in HTML.
            function h(value) {
                if (value === undefined || value === null) return "";

                return String(value)
                    .replaceAll("&", "&amp;")
                    .replaceAll("<", "&lt;")
                    .replaceAll(">", "&gt;")
                    .replaceAll('"', "&quot;")
                    .replaceAll("'", "&#039;");
            }

            try {
                // Hier wird das JavaScript aus dem Script-Textfeld eingefügt.
                {{script}}

                // Das User-Script muss render(data) bereitstellen.
                const result = render(data);

                // Rückgabe aus render(data) wird als HTML angezeigt.
                if (result !== undefined && result !== null) {
                    app.innerHTML = result;
                }
            }
            catch (ex) {
                // JavaScript-Fehler werden direkt in der WebView sichtbar gemacht.
                app.innerHTML =
                    "<pre style='color:red;font-family:Consolas;padding:20px;white-space:pre-wrap;'>"
                    + h(ex.stack || ex.toString())
                    + "</pre>";
            }
        </script>
        """;
    }

    private void ShowInWebView(string html)
    {
        // WebView lädt eine lokale HTML-Datei.
        var file = Path.Combine(
            Path.GetTempPath(),
            $"json-visualizer-{DateTimeOffset.Now.ToUnixTimeMilliseconds()}.html"
        );

        // HTML-Datei schreiben.
        File.WriteAllText(file, html);

        // HTML-Datei in der WebView anzeigen.
        WebPreview.Source = new Uri(file);
    }
}

/*
You are generating a JavaScript visualization script for an Avalonia desktop app called JSON Visualizer Pipeline.



The app has this structure:

1. A JSON input field.

2. A JSON TreeView that already shows the raw JSON structure.

3. A Visualizer Script field where your generated JavaScript will be pasted.

4. A WebView preview area that renders the visualization.



The app provides the parsed JSON to the script as `data`.



Your task:

Generate one complete JavaScript script that can be copied directly into the Visualizer Script field.



Output rules:

- Output only JavaScript code.

- Do not use markdown.

- Do not use code fences.

- Do not explain the code.

- Do not write comments outside the code.

- Do not include Postman-specific code.

- Do not use `pm.response.json()`.

- Do not use `pm.visualizer.set()`.

- Do not use Handlebars syntax like `{{value}}`.

- Do not use TypeScript.

- Use plain JavaScript only.



Required runtime contract:

The script must define this function:



function render(data) {

return `

<style>

/* CSS here * /

</style>



<div>

<!-- HTML here -->

</div>

`;

}



Available global objects and helpers:

- `data` contains the parsed JSON object or array.

- `app` is the root DOM element of the WebView output area.

- `h(value)` is available and safely escapes dynamic values for HTML output.

- The script runs inside a browser/WebView environment.



Important:

- For normal visualizations, return one HTML string from `render(data)`.

- The returned HTML string should include a `<style>` block and one root wrapper element.

- Use `h(value)` for all dynamic text from the JSON.

- Use bracket notation for JSON keys with special characters.

Example: data["switch:0"]

- Use defensive access patterns because some fields may be missing.

Example:

const device = data["switch:0"] || {};

const wifi = data.wifi || {};



Visualization goal:

Create a useful, readable dashboard based on the JSON structure and the optional description.



The raw JSON structure is already visible in the TreeView. Therefore, do not simply recreate the full JSON tree unless no better visualization is possible. Instead, interpret the data and create a meaningful UI.



Recommended UI elements:

- Cards for important values

- Tables for grouped details

- Badges for statuses

- Simple CSS bar charts for numeric arrays

- Lists for repeated records

- Sections for logical data groups

- Clear labels and units where possible



Interpretation rules:

- Boolean values should be shown as clear status indicators, such as ON/OFF, connected/disconnected, true/false.

- Numeric values should be shown with units when the unit is obvious from the key name.

- Arrays of numbers can be visualized as simple bar charts.

- Timestamps, dates and times should be formatted clearly when possible.

- Location, temperature, power, voltage, current, network status, device state and system information should be grouped logically.

- Missing values should not break the visualization. Show "N/A" or an empty state instead.

- The visualization should still render even if only part of the expected JSON is available.



Security and robustness rules:

- Always escape dynamic text with `h(value)`.

- Do not escape calculated numeric CSS values, but make sure they are valid numbers before using them in CSS.

- Do not rely on external images.

- Prefer not to use external libraries.

- If an external JavaScript library is absolutely necessary, load it dynamically by creating a script element in JavaScript.

- Do not include `<script>` tags inside the returned HTML string, because scripts inserted through `innerHTML` may not execute reliably.

- For asynchronous visualizations, set `app.innerHTML` inside `render(data)` and return nothing.



Layout rules:

- Include CSS inside a `<style>` tag.

- Use one root wrapper, for example `<div class="dashboard">...</div>`.

- Make the design fit inside a WebView.

- Use readable spacing, typography and hierarchy.

- Use responsive layout techniques such as CSS grid or flexbox.

- Use `min-height: 100vh` only when a full dashboard layout is useful.

- Do not include a full `<!DOCTYPE html>`, `<html>`, `<head>` or `<body>` document.



Simple valid example:



function render(data) {

return `

<style>

.dashboard {

font-family: Arial, sans-serif;

padding: 20px;

}



pre {

background: #111;

color: #00ff99;

padding: 16px;

border-radius: 8px;

overflow: auto;

}

</style>



<div class="dashboard">

<h1>JSON Visualization</h1>

<pre>${h(JSON.stringify(data, null, 2))}</pre>

</div>

`;

}



Data interpretation task:

Analyze the JSON below. Use the optional description if provided. Infer what the data source represents and create the most useful visualization for it.



Return only the final JavaScript code for the Visualizer Script field.



JSON DATA:

[PASTE JSON HERE]


OPTIONAL DATA SOURCE DESCRIPTION:

[OPTIONAL: Write 1-3 sentences about the data source and what should be visualized. Example: "This JSON comes from a Shelly smart plug. It measures electricity consumption, voltage, current, temperature, WiFi status and device system information. I want a practical device dashboard."]
*/