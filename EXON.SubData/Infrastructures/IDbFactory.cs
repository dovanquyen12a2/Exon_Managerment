namespace EXON.SubData.Infrastructures
{
    public interface IDbFactory
    {
        MTAQuizDbContext Init();
    }
}