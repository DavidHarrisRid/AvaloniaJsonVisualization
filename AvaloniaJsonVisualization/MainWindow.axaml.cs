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

        JsonInput.Text = """{ "name": "Device", "power": 42 }""";

        ScriptInput.Text = """
                           function render(data) {
                               return `
                                   <div style="padding: 28px;"> 
                                        <h1 style="color: #FACC15; font-size: 34px;">${h(data.name)}</h1> 
                                        <p style="color: #D1D5DB; font-size: 22px; ">${h(data.power)} W</p> 
                                    </div>
                               `;
                           }
                           """;

        RunPipeline();
    }
    
    
    private void HelpButton_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        WebPreview.IsVisible = false;
        WebPreviewBox.IsVisible = false;

        HelpOverlay.IsVisible = true;
    }

    private void CloseHelpButton_OnClick(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        HelpOverlay.IsVisible = false;

        WebPreviewBox.IsVisible = true;
        WebPreview.IsVisible = true;
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