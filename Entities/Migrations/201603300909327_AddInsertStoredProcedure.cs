using System.Data.Entity.Migrations;


namespace Entities.Migrations
{
    public partial class AddInsertStoredProcedure: DbMigration
    {
        #region Override
        public override void Down()
        {
            DropStoredProcedure("dbo.File_Delete");
            DropStoredProcedure("dbo.File_Update");
            DropStoredProcedure("dbo.InsertFile");
            DropTable("dbo.Files");
        }

        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    CreatedOn = c.DateTime(),
                    ModifiedOn = c.DateTime(),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateStoredProcedure(
                "dbo.InsertFile",
                p => new
                {
                    Name = p.String(),
                },
                body:
                    @"INSERT [dbo].[Files]([CreatedOn], [ModifiedOn], [Name])
                      VALUES (GETDATE(), GETDATE(), @Name)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Files]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Files] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
                );

            CreateStoredProcedure(
                "dbo.File_Update",
                p => new
                {
                    Id = p.Int(),
                    Name = p.String(),
                },
                body:
                    @"UPDATE [dbo].[Files]
                      SET [ModifiedOn] = GETDATE(), [Name] = @Name
                      WHERE ([Id] = @Id)"
                );

            CreateStoredProcedure(
                "dbo.File_Delete",
                p => new
                {
                    Id = p.Int(),
                },
                body:
                    @"DELETE [dbo].[Files]
                      WHERE ([Id] = @Id)"
                );
        }
        #endregion
    }
}