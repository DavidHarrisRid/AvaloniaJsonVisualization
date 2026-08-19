using System.Collections.Generic;

namespace AvaloniaJsonVisualization;

public sealed class VisualizationSample
{
    public VisualizationSample(string name, string description, string json, string script)
    {
        Name = name;
        Description = description;
        Json = json;
        Script = script;
    }

    public string Name { get; }

    public string Description { get; }

    public string Json { get; }

    public string Script { get; }

    public override string ToString()
    {
        return Name;
    }
}

public static class VisualizationSamples
{
    public static IReadOnlyList<VisualizationSample> All { get; } =
    [
        new VisualizationSample(
            name: "Simple example",
            description: "A minimal example that shows how JSON fields become data.name and data.power.",
            json: """{ "name": "Device", "power": 42 }""",
            script: """
            function render(data) {
                return `
                    <div style="padding: 28px;"> 
                        <h1 style="color: #FACC15; font-size: 34px;">${h(data.name)}</h1> 
                        <p style="color: #D1D5DB; font-size: 22px;">${h(data.power)} W</p> 
                    </div>
                `;
            }
            """
        ),

        // Wetterdaten sind von Open Meteo
        new VisualizationSample(
            name: "Expert example",
            description: "A large example that show how JSON can be visualised in JavaScript",
            json: """
            [
              {
                "city": "Kabul",
                "region": "Asia",
                "latitude": 34.551846,
                "longitude": 69.23077,
                "timezone": "Asia/Kabul",
                "current": {
                  "time": "2026-07-09T15:45",
                  "temperature_2m": 32.8
                }
              },
              {
                "city": "Dhaka",
                "region": "Asia",
                "latitude": 23.725834,
                "longitude": 90.38015,
                "timezone": "Asia/Dhaka",
                "current": {
                  "time": "2026-07-09T17:15",
                  "temperature_2m": 27.6
                }
              },
              {
                "city": "Beijing",
                "region": "Asia",
                "latitude": 39.89455,
                "longitude": 116.35983,
                "timezone": "Asia/Shanghai",
                "current": {
                  "time": "2026-07-09T19:15",
                  "temperature_2m": 31.0
                }
              },
              {
                "city": "Tokyo",
                "region": "Asia",
                "latitude": 35.7,
                "longitude": 139.6875,
                "timezone": "Asia/Tokyo",
                "current": {
                  "time": "2026-07-09T20:15",
                  "temperature_2m": 24.8
                }
              },
              {
                "city": "Dubai",
                "region": "Middle East",
                "latitude": 24.428822,
                "longitude": 54.364998,
                "timezone": "Asia/Dubai",
                "current": {
                  "time": "2026-07-09T15:15",
                  "temperature_2m": 37.2
                }
              },
              {
                "city": "Baghdad",
                "region": "Middle East",
                "latitude": 33.3125,
                "longitude": 44.375,
                "timezone": "Asia/Baghdad",
                "current": {
                  "time": "2026-07-09T14:15",
                  "temperature_2m": 42.3
                }
              },
              {
                "city": "Berlin",
                "region": "Europe",
                "latitude": 52.52,
                "longitude": 13.419998,
                "timezone": "Europe/Berlin",
                "current": {
                  "time": "2026-07-09T13:15",
                  "temperature_2m": 21.0
                }
              },
              {
                "city": "Vienna",
                "region": "Europe",
                "latitude": 48.2,
                "longitude": 16.38,
                "timezone": "Europe/Vienna",
                "current": {
                  "time": "2026-07-09T13:15",
                  "temperature_2m": 25.1
                }
              },
              {
                "city": "London",
                "region": "Europe",
                "latitude": 51.5,
                "longitude": -0.25,
                "timezone": "Europe/London",
                "current": {
                  "time": "2026-07-09T12:15",
                  "temperature_2m": 30.6
                }
              },
              {
                "city": "Reykjavik",
                "region": "Europe",
                "latitude": 64.12922,
                "longitude": -21.883698,
                "timezone": "Atlantic/Reykjavik",
                "current": {
                  "time": "2026-07-09T11:15",
                  "temperature_2m": 12.3
                }
              },
              {
                "city": "Algiers",
                "region": "Africa",
                "latitude": 36.75,
                "longitude": 3.0625,
                "timezone": "Africa/Algiers",
                "current": {
                  "time": "2026-07-09T12:15",
                  "temperature_2m": 32.4
                }
              },
              {
                "city": "Cairo",
                "region": "Africa",
                "latitude": 30.0625,
                "longitude": 31.25,
                "timezone": "Africa/Cairo",
                "current": {
                  "time": "2026-07-09T14:15",
                  "temperature_2m": 33.3
                }
              },
              {
                "city": "Luanda",
                "region": "Africa",
                "latitude": -8.822495,
                "longitude": 13.278688,
                "timezone": "Africa/Luanda",
                "current": {
                  "time": "2026-07-09T12:15",
                  "temperature_2m": 21.9
                }
              },
              {
                "city": "Nairobi",
                "region": "Africa",
                "latitude": -1.3005272,
                "longitude": 36.824646,
                "timezone": "Africa/Nairobi",
                "current": {
                  "time": "2026-07-09T14:15",
                  "temperature_2m": 26.2
                }
              },
              {
                "city": "Djibouti",
                "region": "Africa",
                "latitude": 11.564148,
                "longitude": 43.151787,
                "timezone": "Africa/Djibouti",
                "current": {
                  "time": "2026-07-09T14:15",
                  "temperature_2m": 44.1
                }
              },
              {
                "city": "Ouagadougou",
                "region": "Africa",
                "latitude": 12.337434,
                "longitude": -1.5419312,
                "timezone": "Africa/Ouagadougou",
                "current": {
                  "time": "2026-07-09T11:15",
                  "temperature_2m": 34.9
                }
              },
              {
                "city": "Ottawa",
                "region": "North America",
                "latitude": 45.406376,
                "longitude": -75.71817,
                "timezone": "America/Toronto",
                "current": {
                  "time": "2026-07-09T07:15",
                  "temperature_2m": 21.1
                }
              },
              {
                "city": "Washington",
                "region": "North America",
                "latitude": 38.890526,
                "longitude": -77.02716,
                "timezone": "America/New_York",
                "current": {
                  "time": "2026-07-09T07:15",
                  "temperature_2m": 24.2
                }
              },
              {
                "city": "Mexico City",
                "region": "North America",
                "latitude": 19.437609,
                "longitude": -99.10715,
                "timezone": "America/Mexico_City",
                "current": {
                  "time": "2026-07-09T05:15",
                  "temperature_2m": 13.3
                }
              },
              {
                "city": "Bogota",
                "region": "South America",
                "latitude": 4.674868,
                "longitude": -74.11331,
                "timezone": "America/Bogota",
                "current": {
                  "time": "2026-07-09T06:15",
                  "temperature_2m": 12.0
                }
              },
              {
                "city": "Quito",
                "region": "South America",
                "latitude": -0.17574693,
                "longitude": -78.486755,
                "timezone": "America/Guayaquil",
                "current": {
                  "time": "2026-07-09T06:15",
                  "temperature_2m": 9.6
                }
              },
              {
                "city": "Santiago",
                "region": "South America",
                "latitude": -33.427067,
                "longitude": -70.64276,
                "timezone": "America/Santiago",
                "current": {
                  "time": "2026-07-09T07:15",
                  "temperature_2m": 13.1
                }
              },
              {
                "city": "Buenos Aires",
                "region": "South America",
                "latitude": -34.622143,
                "longitude": -58.40909,
                "timezone": "America/Argentina/Buenos_Aires",
                "current": {
                  "time": "2026-07-09T08:15",
                  "temperature_2m": 10.2
                }
              },
              {
                "city": "Brasilia",
                "region": "South America",
                "latitude": -15.782073,
                "longitude": -47.97168,
                "timezone": "America/Sao_Paulo",
                "current": {
                  "time": "2026-07-09T08:15",
                  "temperature_2m": 19.2
                }
              },
              {
                "city": "Canberra",
                "region": "Oceania",
                "latitude": -35.32513,
                "longitude": 149.156,
                "timezone": "Australia/Sydney",
                "current": {
                  "time": "2026-07-09T21:15",
                  "temperature_2m": 4.4
                }
              },
              {
                "city": "Wellington",
                "region": "Oceania",
                "latitude": -41.300526,
                "longitude": 174.70589,
                "timezone": "Pacific/Auckland",
                "current": {
                  "time": "2026-07-09T23:15",
                  "temperature_2m": 8.7
                }
              },
              {
                "city": "Suva",
                "region": "Oceania",
                "latitude": -18.101934,
                "longitude": 178.42259,
                "timezone": "Pacific/Fiji",
                "current": {
                  "time": "2026-07-09T23:15",
                  "temperature_2m": 17.1
                }
              },
              {
                "city": "Tarawa",
                "region": "Oceania",
                "latitude": 1.3005272,
                "longitude": 172.9621,
                "timezone": "Pacific/Tarawa",
                "current": {
                  "time": "2026-07-09T23:15",
                  "temperature_2m": 28.4
                }
              }
            ]
            """,
            script: """
            function render(data) {
              function getLocationInfo(loc) {
                const info = {
                  city: loc && loc.city ? loc.city : "Unbekannt",
                  region: loc && loc.region ? loc.region : "Unbekannt"
                };
            
                if ((!loc.city || !loc.region) && loc && loc.timezone && loc.timezone.includes("/")) {
                  const parts = loc.timezone.split("/");
                  info.region = info.region !== "Unbekannt"
                    ? info.region
                    : (parts[0] || "Unbekannt").replace(/_/g, " ");
            
                  info.city = info.city !== "Unbekannt"
                    ? info.city
                    : (parts[parts.length - 1] || "Unbekannt").replace(/_/g, " ");
                }
            
                return info;
              }
            
              const locations = [];
            
              if (Array.isArray(data)) {
                data.forEach(function (loc, idx) {
                  const locInfo = getLocationInfo(loc);
            
                  const temp =
                    loc &&
                    loc.current &&
                    loc.current.temperature_2m !== undefined &&
                    loc.current.temperature_2m !== null
                      ? Number(loc.current.temperature_2m)
                      : null;
            
                  locations.push({
                    id: idx,
                    city: locInfo.city,
                    region: locInfo.region,
                    lat: Number(loc.latitude),
                    lon: Number(loc.longitude),
                    temp: temp
                  });
                });
              }
            
              locations.sort(function (a, b) {
                const regionCmp = a.region.localeCompare(b.region, undefined, { sensitivity: "base" });
                if (regionCmp !== 0) return regionCmp;
                return a.city.localeCompare(b.city, undefined, { sensitivity: "base" });
              });
            
              const validTemps = locations
                .filter(function (r) { return r.temp !== null && !isNaN(r.temp); })
                .map(function (r) { return r.temp; });
            
              const minTemp = validTemps.length ? Math.min.apply(null, validTemps) : 0;
              const maxTemp = validTemps.length ? Math.max.apply(null, validTemps) : 1;
            
              function tempToColor(t) {
                if (t === null || isNaN(t)) return "#9aa0a6";
            
                const range = maxTemp - minTemp;
                const ratio = range === 0 ? 0.5 : (t - minTemp) / range;
            
                let r, g, b;
            
                if (ratio < 0.5) {
                  const f = ratio * 2;
                  r = Math.round(f * 255);
                  g = Math.round(f * 255);
                  b = 255;
                } else {
                  const f = (ratio - 0.5) * 2;
                  r = 255;
                  g = Math.round((1 - f) * 255);
                  b = 0;
                }
            
                return "rgb(" + r + "," + g + "," + b + ")";
              }
            
              locations.forEach(function (r) {
                r.color = tempToColor(r.temp);
                r.tempLabel = r.temp !== null && !isNaN(r.temp) ? r.temp.toFixed(1) + " °C" : "N/A";
                r.pointId = "p-" + r.id;
              });
            
              const tableRows = locations.map(function (location) {
                return `
                  <tr class="city-row" data-point-id="${location.pointId}">
                    <td>
                      <div class="city-cell">
                        <span class="dot" style="background:${location.color}"></span>
                        <span class="city-name">${h(location.city)}</span>
                      </div>
                    </td>
                    <td><span class="region-text">${h(location.region)}</span></td>
                    <td class="temp-display">${h(location.tempLabel)}</td>
                  </tr>
                `;
              }).join("");
            
              const template = `
            <style>
              * { box-sizing: border-box; }
            
              body {
                margin: 0;
                font-family: Inter, "Segoe UI", Roboto, Arial, sans-serif;
                background: #ffffff;
                color: #000000;
                overflow: hidden;
              }
            
              #json-globe-root {
                width: 100%;
                height: 100vh;
                background: #ffffff;
                color: #000000;
                overflow: hidden;
              }
            
              #main-layout {
                display: grid;
                grid-template-columns: minmax(0, 1.6fr) minmax(420px, 0.9fr);
                width: 100%;
                height: 100vh;
                overflow: hidden;
              }
            
              #globe-panel {
                height: 100vh;
                background:
                  radial-gradient(circle at 50% 42%, rgba(55, 87, 122, 0.9) 0%, rgba(16, 23, 33, 1) 45%, rgba(4, 8, 14, 1) 100%);
                border-right: 1px solid #111;
                overflow: hidden;
                position: relative;
              }
            
              #header-fixed {
                position: relative;
                width: 100%;
                height: 100%;
                overflow: hidden;
                box-shadow: inset -10px 0 30px rgba(0,0,0,0.25);
              }
            
              #globe {
                width: 100%;
                height: 100%;
                display: block;
                cursor: grab;
              }
            
              #globe:active {
                cursor: grabbing;
              }
            
              #tooltip {
                position: absolute;
                display: none;
                left: 0;
                top: 0;
                transform: translate(-50%, calc(-100% - 12px));
                background: rgba(255,255,255,0.98);
                color: #000;
                padding: 10px 12px;
                border-radius: 10px;
                border: 2px solid #000;
                font-size: 14px;
                font-weight: 800;
                line-height: 1.35;
                pointer-events: none;
                z-index: 50;
                white-space: nowrap;
                box-shadow: 0 10px 24px rgba(0,0,0,0.22);
              }
            
              #tooltip::after {
                content: "";
                position: absolute;
                left: 50%;
                bottom: -10px;
                transform: translateX(-50%);
                width: 0;
                height: 0;
                border-left: 10px solid transparent;
                border-right: 10px solid transparent;
                border-top: 10px solid #000;
              }
            
              #side-panel {
                height: 100vh;
                display: flex;
                flex-direction: column;
                background: #ffffff;
                overflow: hidden;
              }
            
              #search-area {
                position: relative;
                z-index: 20;
                background: linear-gradient(180deg, #111 0%, #050505 100%);
                padding: 16px 18px;
                border-bottom: 1px solid #111;
                box-shadow: 0 6px 16px rgba(0,0,0,0.14);
                flex: 0 0 auto;
              }
            
              .search-shell {
                width: 100%;
                margin: 0 auto;
                position: relative;
              }
            
              #search-input {
                width: 100%;
                padding: 14px 18px;
                font-size: 18px;
                font-weight: 800;
                color: #000;
                background: #fff;
                border: 3px solid #fff;
                border-radius: 14px;
                outline: none;
                box-shadow: 0 8px 20px rgba(0,0,0,0.2);
                transition: border-color 0.15s ease, box-shadow 0.15s ease;
              }
            
              #search-input:focus {
                border-color: #8ab4ff;
                box-shadow: 0 0 0 4px rgba(138, 180, 255, 0.18), 0 8px 20px rgba(0,0,0,0.22);
              }
            
              #suggestions {
                display: none;
                position: absolute;
                left: 0;
                right: 0;
                top: calc(100% + 8px);
                background: #fff;
                border: 2px solid #000;
                border-radius: 14px;
                overflow: hidden;
                box-shadow: 0 14px 30px rgba(0,0,0,0.3);
                z-index: 60;
                max-height: 320px;
                overflow-y: auto;
              }
            
              .suggestion-item {
                padding: 12px 16px;
                border-bottom: 1px solid #ececec;
                cursor: pointer;
                background: #fff;
                transition: background 0.12s ease;
              }
            
              .suggestion-item:last-child {
                border-bottom: none;
              }
            
              .suggestion-item:hover,
              .suggestion-item.selected {
                background: #eceff3;
              }
            
              .suggestion-city {
                display: block;
                font-size: 16px;
                font-weight: 900;
                color: #000;
              }
            
              .suggestion-region {
                display: block;
                font-size: 13px;
                font-weight: 700;
                color: #444;
                margin-top: 2px;
              }
            
              #scroll-container {
                flex: 1 1 auto;
                overflow-y: auto;
                background: #fff;
              }
            
              .content {
                padding: 18px;
              }
            
              .table-wrap {
                width: 100%;
                border: 1px solid #e8e8e8;
                border-radius: 16px;
                overflow: hidden;
                background: #fff;
                box-shadow: 0 10px 28px rgba(0,0,0,0.08);
              }
            
              table {
                width: 100%;
                border-collapse: collapse;
                background: #fff;
              }
            
              thead th {
                position: sticky;
                top: 0;
                z-index: 10;
                background: #000;
                color: #fff;
                padding: 14px 16px;
                text-align: left;
                font-size: 14px;
                font-weight: 900;
                letter-spacing: 0.04em;
                text-transform: uppercase;
              }
            
              thead th:last-child {
                text-align: right;
              }
            
              tbody td {
                padding: 14px 16px;
                border-bottom: 1px solid #ececec;
                font-size: 16px;
                font-weight: 900;
                color: #000 !important;
                background: #fff;
                vertical-align: middle;
              }
            
              tbody tr:last-child td {
                border-bottom: none;
              }
            
              tbody tr.city-row {
                cursor: pointer;
                transition: background 0.12s ease, transform 0.12s ease;
              }
            
              tbody tr.city-row:hover td {
                background: #f5f7fa;
              }
            
              tbody tr.city-row.active-row td {
                background: #eef4ff;
              }
            
              .city-cell {
                display: flex;
                align-items: center;
                gap: 10px;
              }
            
              .dot {
                width: 14px;
                height: 14px;
                border-radius: 999px;
                border: 1px solid #000;
                flex: 0 0 14px;
                box-shadow: 0 1px 2px rgba(0,0,0,0.18);
              }
            
              .city-name {
                font-size: 17px;
                font-weight: 900;
                color: #000;
              }
            
              .region-text {
                font-size: 16px;
                font-weight: 900;
                color: #000;
              }
            
              .temp-display {
                font-size: 16px;
                font-weight: 900;
                color: #000 !important;
                text-align: right;
                white-space: nowrap;
              }
            
              .water {
                fill: #0a1118;
              }
            
              .land {
                fill: #2d4055;
                stroke: #506070;
                stroke-width: 0.35px;
                pointer-events: none;
              }
            
              .point {
                stroke: rgba(255,255,255,0.9);
                stroke-width: 0.9px;
                cursor: pointer;
                transition: opacity 0.15s ease;
              }
            
              .hover-point {
                stroke-width: 2px !important;
              }
            
              .active-point {
                stroke: #ffffff !important;
                stroke-width: 4px !important;
                filter: drop-shadow(0 0 8px rgba(255,255,255,0.95));
              }
            
              @media (max-width: 980px) {
                #main-layout {
                  grid-template-columns: 1fr;
                  grid-template-rows: 360px 1fr;
                }
            
                #globe-panel {
                  height: 360px;
                  border-right: none;
                  border-bottom: 1px solid #111;
                }
            
                #side-panel {
                  height: calc(100vh - 360px);
                }
              }
            </style>
            
            <div id="json-globe-root">
              <div id="main-layout">
            
                <div id="globe-panel">
                  <div id="header-fixed">
                    <div id="tooltip"></div>
                    <svg id="globe"></svg>
                  </div>
                </div>
            
                <div id="side-panel">
                  <div id="search-area">
                    <div class="search-shell">
                      <input
                        id="search-input"
                        type="text"
                        autocomplete="off"
                        placeholder="Stadt suchen – Pfeiltasten für Vorschläge, Enter zum Öffnen"
                      />
                      <div id="suggestions"></div>
                    </div>
                  </div>
            
                  <div id="scroll-container">
                    <div class="content">
                      <div class="table-wrap">
                        <table>
                          <thead>
                            <tr>
                              <th>Stadt</th>
                              <th>Region</th>
                              <th>Temp.</th>
                            </tr>
                          </thead>
                          <tbody id="table-body">
                            ${tableRows}
                          </tbody>
                        </table>
                      </div>
                    </div>
                  </div>
                </div>
            
              </div>
            </div>
            `;
            
              window.__jsonGlobeRunId = (window.__jsonGlobeRunId || 0) + 1;
              const runId = window.__jsonGlobeRunId;
            
              function loadScriptOnce(src, globalName) {
                return new Promise(function (resolve, reject) {
                  if (window[globalName]) {
                    resolve();
                    return;
                  }
            
                  const existing = document.querySelector('script[data-json-globe-lib="' + globalName + '"]');
            
                  if (existing) {
                    existing.addEventListener("load", function () { resolve(); });
                    existing.addEventListener("error", reject);
                    return;
                  }
            
                  const script = document.createElement("script");
                  script.src = src;
                  script.async = true;
                  script.dataset.jsonGlobeLib = globalName;
                  script.onload = function () { resolve(); };
                  script.onerror = reject;
            
                  document.head.appendChild(script);
                });
              }
            
              setTimeout(function () {
                Promise.all([
                  loadScriptOnce("https://d3js.org/d3.v7.min.js", "d3"),
                  loadScriptOnce("https://unpkg.com/topojson@3", "topojson")
                ]).then(function () {
                  if (runId !== window.__jsonGlobeRunId) return;
            
                  const locationByPointId = {};
                  locations.forEach(function (d) {
                    locationByPointId[d.pointId] = d;
                  });
            
                  const container = document.getElementById("header-fixed");
                  const svgEl = document.getElementById("globe");
                  const tooltipEl = document.getElementById("tooltip");
                  const searchInput = document.getElementById("search-input");
                  const suggestionsDiv = document.getElementById("suggestions");
                  const tableRows = Array.from(document.querySelectorAll(".city-row"));
            
                  if (!container || !svgEl || !tooltipEl || !searchInput || !suggestionsDiv) {
                    return;
                  }
            
                  let width = container.clientWidth || window.innerWidth;
                  let height = container.clientHeight || 640;
                  const baseScale = 220;
            
                  let currentMatches = [];
                  let selectedIndex = -1;
                  let mapReady = false;
                  let lockedLocation = null;
            
                  const svg = d3.select("#globe")
                    .attr("width", width)
                    .attr("height", height);
            
                  let projection = d3.geoOrthographic()
                    .scale(baseScale)
                    .translate([width / 2, height / 2])
                    .clipAngle(90)
                    .precision(0.3);
            
                  const path = d3.geoPath().projection(projection);
            
                  const ocean = svg.append("circle")
                    .attr("class", "water")
                    .attr("cx", width / 2)
                    .attr("cy", height / 2)
                    .attr("r", projection.scale());
            
                  let world = null;
                  let points = null;
            
                  function normalizeDelta(start, end) {
                    let delta = end - start;
                    while (delta > 180) delta -= 360;
                    while (delta < -180) delta += 360;
                    return delta;
                  }
            
                  function isFrontFacing(d) {
                    const center = projection.invert([width / 2, height / 2]);
                    if (!center) return false;
                    return d3.geoDistance([d.lon, d.lat], center) <= Math.PI / 2;
                  }
            
                  function getProjectedPoint(d) {
                    return projection([d.lon, d.lat]);
                  }
            
                  function showTooltipForLocation(d) {
                    const p = getProjectedPoint(d);
            
                    if (!p || !isFrontFacing(d)) {
                      tooltipEl.style.display = "none";
                      return;
                    }
            
                    tooltipEl.innerHTML =
                      "<div>STADT: " + d.city + "</div>" +
                      "<div>TEMP: " + d.tempLabel + "</div>";
            
                    tooltipEl.style.left = p[0] + "px";
                    tooltipEl.style.top = p[1] + "px";
                    tooltipEl.style.display = "block";
                  }
            
                  function hideTooltip() {
                    tooltipEl.style.display = "none";
                  }
            
                  function clearActivePoint() {
                    d3.selectAll(".point").classed("active-point", false);
                  }
            
                  function setActivePoint(pointId) {
                    clearActivePoint();
                    if (pointId) {
                      d3.select("#" + pointId).classed("active-point", true);
                    }
                  }
            
                  function clearActiveRows() {
                    tableRows.forEach(function (row) {
                      row.classList.remove("active-row");
                    });
                  }
            
                  function setActiveRow(pointId) {
                    clearActiveRows();
                    tableRows.forEach(function (row) {
                      if (row.dataset.pointId === pointId) {
                        row.classList.add("active-row");
                      }
                    });
                  }
            
                  function renderGlobe() {
                    ocean
                      .attr("cx", width / 2)
                      .attr("cy", height / 2)
                      .attr("r", projection.scale());
            
                    if (world) {
                      world.attr("d", path);
                    }
            
                    if (points) {
                      points
                        .attr("cx", function (d) {
                          const p = getProjectedPoint(d);
                          return p ? p[0] : -9999;
                        })
                        .attr("cy", function (d) {
                          const p = getProjectedPoint(d);
                          return p ? p[1] : -9999;
                        })
                        .style("fill", function (d) { return d.color; })
                        .style("display", function (d) {
                          return isFrontFacing(d) ? "inline" : "none";
                        });
                    }
            
                    if (lockedLocation) {
                      showTooltipForLocation(lockedLocation);
                    }
                  }
            
                  function clearLockedSelection() {
                    lockedLocation = null;
                    clearActivePoint();
                    clearActiveRows();
                    hideTooltip();
                  }
            
                  function flyToLocation(d) {
                    if (!mapReady) return;
            
                    hideTooltip();
                    clearActivePoint();
                    clearActiveRows();
                    lockedLocation = null;
            
                    const start = projection.rotate();
                    const target = [-d.lon, -d.lat, 0];
            
                    const end = [
                      start[0] + normalizeDelta(start[0], target[0]),
                      start[1] + normalizeDelta(start[1], target[1]),
                      0
                    ];
            
                    d3.transition()
                      .duration(1100)
                      .ease(d3.easeCubicInOut)
                      .tween("rotate", function () {
                        const lonI = d3.interpolateNumber(start[0], end[0]);
                        const latI = d3.interpolateNumber(start[1], end[1]);
            
                        return function (t) {
                          projection.rotate([lonI(t), latI(t), 0]);
                          renderGlobe();
                        };
                      })
                      .on("end", function () {
                        lockedLocation = d;
                        setActivePoint(d.pointId);
                        setActiveRow(d.pointId);
                        showTooltipForLocation(d);
                      });
                  }
            
                  function activateLocation(d) {
                    searchInput.value = d.city;
                    suggestionsDiv.style.display = "none";
                    currentMatches = [];
                    selectedIndex = -1;
                    flyToLocation(d);
                  }
            
                  function renderSuggestions() {
                    suggestionsDiv.innerHTML = "";
            
                    if (!currentMatches.length) {
                      suggestionsDiv.style.display = "none";
                      return;
                    }
            
                    currentMatches.forEach(function (m, i) {
                      const item = document.createElement("div");
                      item.className = "suggestion-item" + (i === selectedIndex ? " selected" : "");
            
                      const city = document.createElement("span");
                      city.className = "suggestion-city";
                      city.textContent = m.city;
            
                      const region = document.createElement("span");
                      region.className = "suggestion-region";
                      region.textContent = m.region + " • " + m.tempLabel;
            
                      item.appendChild(city);
                      item.appendChild(region);
            
                      item.addEventListener("mouseenter", function () {
                        selectedIndex = i;
                        renderSuggestions();
                      });
            
                      item.addEventListener("mousedown", function (evt) {
                        evt.preventDefault();
                        evt.stopPropagation();
                        activateLocation(m);
                      });
            
                      suggestionsDiv.appendChild(item);
                    });
            
                    suggestionsDiv.style.display = "block";
                  }
            
                  function updateMatches(inputValue) {
                    const value = (inputValue || "").trim().toLowerCase();
            
                    if (!value) {
                      currentMatches = [];
                      selectedIndex = -1;
                      renderSuggestions();
                      return;
                    }
            
                    currentMatches = locations
                      .filter(function (l) {
                        return (
                          l.city.toLowerCase().includes(value) ||
                          l.region.toLowerCase().includes(value)
                        );
                      })
                      .slice(0, 8);
            
                    selectedIndex = currentMatches.length ? 0 : -1;
                    renderSuggestions();
                  }
            
                  tableRows.forEach(function (row) {
                    row.addEventListener("click", function () {
                      const d = locationByPointId[row.dataset.pointId];
                      if (d) flyToLocation(d);
                    });
                  });
            
                  searchInput.addEventListener("input", function (e) {
                    updateMatches(e.target.value);
                  });
            
                  searchInput.addEventListener("focus", function () {
                    if (searchInput.value.trim()) {
                      updateMatches(searchInput.value);
                    }
                  });
            
                  searchInput.addEventListener("keydown", function (e) {
                    if (!currentMatches.length) return;
            
                    if (e.key === "ArrowDown") {
                      e.preventDefault();
                      selectedIndex = (selectedIndex + 1) % currentMatches.length;
                      renderSuggestions();
                    } else if (e.key === "ArrowUp") {
                      e.preventDefault();
                      selectedIndex = (selectedIndex - 1 + currentMatches.length) % currentMatches.length;
                      renderSuggestions();
                    } else if (e.key === "Enter") {
                      e.preventDefault();
                      const selected =
                        selectedIndex >= 0 && currentMatches[selectedIndex]
                          ? currentMatches[selectedIndex]
                          : currentMatches[0];
            
                      if (selected) {
                        activateLocation(selected);
                      }
                    } else if (e.key === "Escape") {
                      suggestionsDiv.style.display = "none";
                      currentMatches = [];
                      selectedIndex = -1;
                    }
                  });
            
                  document.addEventListener("mousedown", function (e) {
                    if (!e.target.closest(".search-shell")) {
                      suggestionsDiv.style.display = "none";
                    }
                  });
            
                  window.addEventListener("resize", function () {
                    width = container.clientWidth || window.innerWidth;
                    height = container.clientHeight || 640;
            
                    svg.attr("width", width).attr("height", height);
                    projection.translate([width / 2, height / 2]);
            
                    ocean
                      .attr("cx", width / 2)
                      .attr("cy", height / 2);
            
                    renderGlobe();
                  });
            
                  d3.json("https://unpkg.com/world-atlas@2/countries-110m.json").then(function (worldData) {
                    const countries = topojson.feature(worldData, worldData.objects.countries);
            
                    world = svg.append("path")
                      .datum(countries)
                      .attr("class", "land")
                      .attr("d", path);
            
                    points = svg.selectAll(".point")
                      .data(locations)
                      .enter()
                      .append("circle")
                      .attr("class", "point")
                      .attr("id", function (d) { return d.pointId; })
                      .attr("r", 6)
                      .on("mouseover", function (event, d) {
                        if (lockedLocation && lockedLocation.pointId === d.pointId) return;
                        d3.select(this).classed("hover-point", true);
                        showTooltipForLocation(d);
                      })
                      .on("mouseout", function (event, d) {
                        d3.select(this).classed("hover-point", false);
                        if (lockedLocation) {
                          showTooltipForLocation(lockedLocation);
                        } else {
                          hideTooltip();
                        }
                      })
                      .on("click", function (event, d) {
                        flyToLocation(d);
                      });
            
                    svg.call(
                      d3.drag()
                        .on("start", function () {
                          clearLockedSelection();
                        })
                        .on("drag", function (event) {
                          const rotate = projection.rotate();
                          const k = 72 / projection.scale();
            
                          projection.rotate([
                            rotate[0] + event.dx * k,
                            rotate[1] - event.dy * k,
                            0
                          ]);
            
                          renderGlobe();
                        })
                    );
            
                    svg.call(
                      d3.zoom()
                        .scaleExtent([0.75, 3.2])
                        .on("zoom", function (event) {
                          projection.scale(baseScale * event.transform.k);
                          renderGlobe();
                        })
                    );
            
                    mapReady = true;
                    renderGlobe();
                  });
                });
              }, 0);
            
              return template;
            }
            """
        )
    ];
}