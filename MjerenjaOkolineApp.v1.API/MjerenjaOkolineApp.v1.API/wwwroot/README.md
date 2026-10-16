# Smart Plant Monitor — HTML/CSS/JavaScript frontend

Frontend for the current ASP.NET Core API model `MjerenjeOkoline` with fields:

- `Id`
- `DeviceId`
- `TemperaturaC`
- `VlaznostZraka`
- `DatumVrijemePrijemaUtc`

## API endpoint expected

The frontend reads:

`GET /api/MjerenjaOkoline?limit=200`

Expected JSON is the list returned by `MjerenjaOkolineController.GetAll`. ASP.NET Core's default camelCase JSON field names are supported (`deviceId`, `temperaturaC`, `vlaznostZraka`, `datumVrijemePrijemaUtc`); PascalCase is supported too.

The page refreshes automatically every 15 seconds. It has current measurement cards, a temperature/humidity trend chart, reading history, device filter and CSV export.

## Recommended: serve from the same ASP.NET Core project

1. In your `MyApp.v3.API` project, create folder `wwwroot` if it doesn't exist.
2. Copy `index.html`, `styles.css` and `app.js` into `wwwroot`.
3. In `Program.cs`, make sure these middlewares are present before `app.MapControllers()`:

```csharp
app.UseDefaultFiles();
app.UseStaticFiles();
app.MapControllers();
```

If your app currently uses `app.UseHttpsRedirection()`, keep it. In development, open the exact HTTPS URL printed when the API starts, for example `https://localhost:7xxx/`.

Serving the frontend and API from the same origin avoids a separate CORS configuration.

## Separate frontend host

By default, `API_BASE_URL` in `app.js` is an empty string, meaning same-origin. If you host the frontend separately, set `API_BASE_URL` to the ASP.NET Core API origin, e.g. `https://localhost:7042` (without a final slash), and configure CORS in ASP.NET Core to allow that frontend origin. Do not use `localhost` as the API host from an ESP32 device; on the ESP32, localhost means the ESP32 itself.

## Notes

- No demonstration/synthetic data is shown; empty states explain when the database has no readings yet.
- API errors are surfaced in the interface.
- Device freshness is defined as a latest backend receipt within 2 minutes. Adjust `DEVICE_FRESHNESS_MS` in `app.js` if the ESP32 reports at a different interval.
- The graph uses HTML canvas and requires no charting library.
- Google Fonts are an optional visual enhancement. System fonts are used as fallback if the network is unavailable.
