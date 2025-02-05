namespace DevelopmentChallenge.Data.Interfaces
{
    public interface IFormaGeometrica
    {
        decimal CalcularArea();
        decimal CalcularPerimetro();
        string ObtenerNombre(int cantidad, string codigoIdioma);
    }
}
