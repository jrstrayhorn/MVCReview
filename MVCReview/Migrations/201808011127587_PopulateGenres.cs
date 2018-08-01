namespace MVCReview.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenres : DbMigration
    {
        public override void Up()
        {
            // Having to add INDENTITY_INSERT because using an int
            // for primary key instead of a byte
            // if using a byte then dont need identity_insert
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT Genres (Id, Name) VALUES (1, 'Comedy')");
            Sql("INSERT Genres (Id, Name) VALUES (2, 'Action')");
            Sql("INSERT Genres (Id, Name) VALUES (3, 'Family')");
            Sql("INSERT Genres (Id, Name) VALUES (4, 'Romance')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }

        public override void Down()
        {
        }
    }
}
