namespace MjerenjaOkolineApp.v1.API.Dtos
{
    public record MjerenjeOkolineResponse
    (
        int Id,
        string DeviceId,
        decimal TemperaturaC,
        decimal VlaznostZraka,
        DateTime DatumVrijemePrijemaUtc
    );
}
