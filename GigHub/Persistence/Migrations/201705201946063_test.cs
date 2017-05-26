namespace GigHub4.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class AddFollowings : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Followings", name: "Followee_Id", newName: "FolloweeId");
            RenameIndex(table: "dbo.Followings", name: "IX_Followee_Id", newName: "IX_FolloweeId");
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FolloweeId", "FollowerId" });
            DropColumn("dbo.Followings", "FollowId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Followings", "FollowId", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Followings");
            AddPrimaryKey("dbo.Followings", new[] { "FollowId", "FollowerId" });
            RenameIndex(table: "dbo.Followings", name: "IX_FolloweeId", newName: "IX_Followee_Id");
            RenameColumn(table: "dbo.Followings", name: "FolloweeId", newName: "Followee_Id");
        }
    }
}
