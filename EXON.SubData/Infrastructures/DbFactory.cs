namespace EXON.SubData.Infrastructures
{
    public class DbFactory : Disposable, IDbFactory
    {
        private MTAQuizDbContext dbContext;

        public MTAQuizDbContext Init()
        {
            return dbContext ?? (dbContext = new MTAQuizDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}