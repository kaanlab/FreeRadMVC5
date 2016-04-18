namespace FreeRadMVC5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.radacct",
                c => new
                    {
                        RadAcctId = c.Long(nullable: false, identity: true),
                        AcctSessionId = c.String(nullable: false, maxLength: 32, unicode: false),
                        AcctUniqueId = c.String(nullable: false, maxLength: 32, unicode: false),
                        UserName = c.String(nullable: false, maxLength: 64, unicode: false),
                        GroupName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Realm = c.String(maxLength: 64, unicode: false),
                        NasIpAddress = c.String(nullable: false, maxLength: 15, unicode: false),
                        NasPortId = c.String(maxLength: 15, unicode: false),
                        NasPortType = c.String(maxLength: 32, unicode: false),
                        AcctStartTime = c.DateTime(nullable: false, precision: 0),
                        AcctUpdateTime = c.DateTime(nullable: false, precision: 0),
                        AcctStopTime = c.DateTime(nullable: false, precision: 0),
                        AcctInterval = c.Int(),
                        AcctSessionTime = c.Int(),
                        AcctAuthentic = c.String(maxLength: 32, unicode: false),
                        ConnectInfo_start = c.String(maxLength: 50, unicode: false),
                        ConnectInfo_stop = c.String(maxLength: 50, unicode: false),
                        AcctInputOctets = c.Long(),
                        AcctOutputOctets = c.Long(),
                        CalledStationId = c.String(nullable: false, maxLength: 50, unicode: false),
                        CallingStationId = c.String(nullable: false, maxLength: 50, unicode: false),
                        AcctTerminateCause = c.String(nullable: false, maxLength: 32, unicode: false),
                        ServiceType = c.String(maxLength: 32, unicode: false),
                        FramedProtocol = c.String(maxLength: 32, unicode: false),
                        FramedIpAddress = c.String(nullable: false, maxLength: 15, unicode: false),
                    })
                .PrimaryKey(t => t.RadAcctId)
                .Index(t => t.AcctSessionId, name: "acctsessionid")
                .Index(t => t.AcctUniqueId, unique: true, name: "acctuniqueid")
                .Index(t => t.UserName, name: "username")
                .Index(t => t.NasIpAddress, name: "nasipaddress")
                .Index(t => t.AcctStartTime, name: "acctstarttime")
                .Index(t => t.AcctStopTime, name: "acctstoptime")
                .Index(t => t.AcctInterval, name: "acctinterval")
                .Index(t => t.FramedIpAddress, name: "framedipaddress");
            
            CreateTable(
                "dbo.radgroupreply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Attribute = c.String(nullable: false, maxLength: 64, unicode: false),
                        Op = c.String(nullable: false, maxLength: 2, unicode: false),
                        Value = c.String(nullable: false, maxLength: 253, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GroupName, name: "groupname");
            
            CreateTable(
                "dbo.radgroupcheck",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Attribute = c.String(nullable: false, maxLength: 64, unicode: false),
                        Op = c.String(nullable: false, maxLength: 2, unicode: false),
                        Value = c.String(nullable: false, maxLength: 253, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.GroupName, name: "groupname");
            
            CreateTable(
                "dbo.nas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NasName = c.String(nullable: false, maxLength: 128, unicode: false),
                        ShortName = c.String(maxLength: 32, unicode: false),
                        Type = c.String(maxLength: 30, unicode: false),
                        Ports = c.Int(),
                        Secret = c.String(nullable: false, maxLength: 60, unicode: false),
                        Community = c.String(maxLength: 50, unicode: false),
                        Description = c.String(maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.NasName, name: "NasName");
            
            CreateTable(
                "dbo.radreply",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Attribute = c.String(nullable: false, maxLength: 64, unicode: false),
                        Op = c.String(nullable: false, maxLength: 2, unicode: false),
                        Value = c.String(nullable: false, maxLength: 253, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, name: "username");
            
            CreateTable(
                "dbo.radusergroup",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 64, unicode: false),
                        GroupName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, name: "username");
            
            CreateTable(
                "dbo.radcheck",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 64, unicode: false),
                        Attribute = c.String(nullable: false, maxLength: 64, unicode: false),
                        Op = c.String(nullable: false, maxLength: 2, unicode: false),
                        Value = c.String(nullable: false, maxLength: 253, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, name: "username");
            
            CreateStoredProcedure(
                "dbo.AccessLog_Insert",
                p => new
                    {
                        AcctSessionId = p.String(maxLength: 32, unicode: false),
                        AcctUniqueId = p.String(maxLength: 32, unicode: false),
                        UserName = p.String(maxLength: 64, unicode: false),
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Realm = p.String(maxLength: 64, unicode: false),
                        NasIpAddress = p.String(maxLength: 15, unicode: false),
                        NasPortId = p.String(maxLength: 15, unicode: false),
                        NasPortType = p.String(maxLength: 32, unicode: false),
                        AcctStartTime = p.DateTime(),
                        AcctUpdateTime = p.DateTime(),
                        AcctStopTime = p.DateTime(),
                        AcctInterval = p.Int(),
                        AcctSessionTime = p.Int(),
                        AcctAuthentic = p.String(maxLength: 32, unicode: false),
                        ConnectInfo_start = p.String(maxLength: 50, unicode: false),
                        ConnectInfo_stop = p.String(maxLength: 50, unicode: false),
                        AcctInputOctets = p.Long(),
                        AcctOutputOctets = p.Long(),
                        CalledStationId = p.String(maxLength: 50, unicode: false),
                        CallingStationId = p.String(maxLength: 50, unicode: false),
                        AcctTerminateCause = p.String(maxLength: 32, unicode: false),
                        ServiceType = p.String(maxLength: 32, unicode: false),
                        FramedProtocol = p.String(maxLength: 32, unicode: false),
                        FramedIpAddress = p.String(maxLength: 15, unicode: false),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `radacct`(
                      `AcctSessionId`, 
                      `AcctUniqueId`, 
                      `UserName`, 
                      `GroupName`, 
                      `Realm`, 
                      `NasIpAddress`, 
                      `NasPortId`, 
                      `NasPortType`, 
                      `AcctStartTime`, 
                      `AcctUpdateTime`, 
                      `AcctStopTime`, 
                      `AcctInterval`, 
                      `AcctSessionTime`, 
                      `AcctAuthentic`, 
                      `ConnectInfo_start`, 
                      `ConnectInfo_stop`, 
                      `AcctInputOctets`, 
                      `AcctOutputOctets`, 
                      `CalledStationId`, 
                      `CallingStationId`, 
                      `AcctTerminateCause`, 
                      `ServiceType`, 
                      `FramedProtocol`, 
                      `FramedIpAddress`) VALUES (
                      @AcctSessionId, 
                      @AcctUniqueId, 
                      @UserName, 
                      @GroupName, 
                      @Realm, 
                      @NasIpAddress, 
                      @NasPortId, 
                      @NasPortType, 
                      @AcctStartTime, 
                      @AcctUpdateTime, 
                      @AcctStopTime, 
                      @AcctInterval, 
                      @AcctSessionTime, 
                      @AcctAuthentic, 
                      @ConnectInfo_start, 
                      @ConnectInfo_stop, 
                      @AcctInputOctets, 
                      @AcctOutputOctets, 
                      @CalledStationId, 
                      @CallingStationId, 
                      @AcctTerminateCause, 
                      @ServiceType, 
                      @FramedProtocol, 
                      @FramedIpAddress);
                      SELECT
                      `RadAcctId`
                      FROM `radacct`
                       WHERE  row_count() > 0 AND `RadAcctId`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.AccessLog_Update",
                p => new
                    {
                        RadAcctId = p.Long(),
                        AcctSessionId = p.String(maxLength: 32, unicode: false),
                        AcctUniqueId = p.String(maxLength: 32, unicode: false),
                        UserName = p.String(maxLength: 64, unicode: false),
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Realm = p.String(maxLength: 64, unicode: false),
                        NasIpAddress = p.String(maxLength: 15, unicode: false),
                        NasPortId = p.String(maxLength: 15, unicode: false),
                        NasPortType = p.String(maxLength: 32, unicode: false),
                        AcctStartTime = p.DateTime(),
                        AcctUpdateTime = p.DateTime(),
                        AcctStopTime = p.DateTime(),
                        AcctInterval = p.Int(),
                        AcctSessionTime = p.Int(),
                        AcctAuthentic = p.String(maxLength: 32, unicode: false),
                        ConnectInfo_start = p.String(maxLength: 50, unicode: false),
                        ConnectInfo_stop = p.String(maxLength: 50, unicode: false),
                        AcctInputOctets = p.Long(),
                        AcctOutputOctets = p.Long(),
                        CalledStationId = p.String(maxLength: 50, unicode: false),
                        CallingStationId = p.String(maxLength: 50, unicode: false),
                        AcctTerminateCause = p.String(maxLength: 32, unicode: false),
                        ServiceType = p.String(maxLength: 32, unicode: false),
                        FramedProtocol = p.String(maxLength: 32, unicode: false),
                        FramedIpAddress = p.String(maxLength: 15, unicode: false),
                    },
                body:
                    @"UPDATE `radacct` SET `AcctSessionId`=@AcctSessionId, `AcctUniqueId`=@AcctUniqueId, `UserName`=@UserName, `GroupName`=@GroupName, `Realm`=@Realm, `NasIpAddress`=@NasIpAddress, `NasPortId`=@NasPortId, `NasPortType`=@NasPortType, `AcctStartTime`=@AcctStartTime, `AcctUpdateTime`=@AcctUpdateTime, `AcctStopTime`=@AcctStopTime, `AcctInterval`=@AcctInterval, `AcctSessionTime`=@AcctSessionTime, `AcctAuthentic`=@AcctAuthentic, `ConnectInfo_start`=@ConnectInfo_start, `ConnectInfo_stop`=@ConnectInfo_stop, `AcctInputOctets`=@AcctInputOctets, `AcctOutputOctets`=@AcctOutputOctets, `CalledStationId`=@CalledStationId, `CallingStationId`=@CallingStationId, `AcctTerminateCause`=@AcctTerminateCause, `ServiceType`=@ServiceType, `FramedProtocol`=@FramedProtocol, `FramedIpAddress`=@FramedIpAddress WHERE `RadAcctId` = @RadAcctId;"
            );
            
            CreateStoredProcedure(
                "dbo.AccessLog_Delete",
                p => new
                    {
                        RadAcctId = p.Long(),
                    },
                body:
                    @"DELETE FROM `radacct` WHERE `RadAcctId` = @RadAcctId;"
            );
            
            CreateStoredProcedure(
                "dbo.GroupAttribute_Insert",
                p => new
                    {
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `radgroupreply`(
                      `GroupName`, 
                      `Attribute`, 
                      `Op`, 
                      `Value`) VALUES (
                      @GroupName, 
                      @Attribute, 
                      @Op, 
                      @Value);
                      SELECT
                      `Id`
                      FROM `radgroupreply`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.GroupAttribute_Update",
                p => new
                    {
                        Id = p.Int(),
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"UPDATE `radgroupreply` SET `GroupName`=@GroupName, `Attribute`=@Attribute, `Op`=@Op, `Value`=@Value WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.GroupAttribute_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `radgroupreply` WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.Group_Insert",
                p => new
                    {
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `radgroupcheck`(
                      `GroupName`, 
                      `Attribute`, 
                      `Op`, 
                      `Value`) VALUES (
                      @GroupName, 
                      @Attribute, 
                      @Op, 
                      @Value);
                      SELECT
                      `Id`
                      FROM `radgroupcheck`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.Group_Update",
                p => new
                    {
                        Id = p.Int(),
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"UPDATE `radgroupcheck` SET `GroupName`=@GroupName, `Attribute`=@Attribute, `Op`=@Op, `Value`=@Value WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.Group_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `radgroupcheck` WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.Nas_Insert",
                p => new
                    {
                        NasName = p.String(maxLength: 128, unicode: false),
                        ShortName = p.String(maxLength: 32, unicode: false),
                        Type = p.String(maxLength: 30, unicode: false),
                        Ports = p.Int(),
                        Secret = p.String(maxLength: 60, unicode: false),
                        Community = p.String(maxLength: 50, unicode: false),
                        Description = p.String(maxLength: 200, unicode: false),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `nas`(
                      `NasName`, 
                      `ShortName`, 
                      `Type`, 
                      `Ports`, 
                      `Secret`, 
                      `Community`, 
                      `Description`) VALUES (
                      @NasName, 
                      @ShortName, 
                      @Type, 
                      @Ports, 
                      @Secret, 
                      @Community, 
                      @Description);
                      SELECT
                      `Id`
                      FROM `nas`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.Nas_Update",
                p => new
                    {
                        Id = p.Int(),
                        NasName = p.String(maxLength: 128, unicode: false),
                        ShortName = p.String(maxLength: 32, unicode: false),
                        Type = p.String(maxLength: 30, unicode: false),
                        Ports = p.Int(),
                        Secret = p.String(maxLength: 60, unicode: false),
                        Community = p.String(maxLength: 50, unicode: false),
                        Description = p.String(maxLength: 200, unicode: false),
                    },
                body:
                    @"UPDATE `nas` SET `NasName`=@NasName, `ShortName`=@ShortName, `Type`=@Type, `Ports`=@Ports, `Secret`=@Secret, `Community`=@Community, `Description`=@Description WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.Nas_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `nas` WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.UserAttribute_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `radreply`(
                      `UserName`, 
                      `Attribute`, 
                      `Op`, 
                      `Value`) VALUES (
                      @UserName, 
                      @Attribute, 
                      @Op, 
                      @Value);
                      SELECT
                      `Id`
                      FROM `radreply`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.UserAttribute_Update",
                p => new
                    {
                        Id = p.Int(),
                        UserName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"UPDATE `radreply` SET `UserName`=@UserName, `Attribute`=@Attribute, `Op`=@Op, `Value`=@Value WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.UserAttribute_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `radreply` WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.UserGroup_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 64, unicode: false),
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Priority = p.Int(),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `radusergroup`(
                      `UserName`, 
                      `GroupName`, 
                      `Priority`) VALUES (
                      @UserName, 
                      @GroupName, 
                      @Priority);
                      SELECT
                      `Id`
                      FROM `radusergroup`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.UserGroup_Update",
                p => new
                    {
                        Id = p.Int(),
                        UserName = p.String(maxLength: 64, unicode: false),
                        GroupName = p.String(maxLength: 64, unicode: false),
                        Priority = p.Int(),
                    },
                body:
                    @"UPDATE `radusergroup` SET `UserName`=@UserName, `GroupName`=@GroupName, `Priority`=@Priority WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.UserGroup_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `radusergroup` WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.User_Insert",
                p => new
                    {
                        UserName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"SET SESSION sql_mode='ANSI';INSERT INTO `radcheck`(
                      `UserName`, 
                      `Attribute`, 
                      `Op`, 
                      `Value`) VALUES (
                      @UserName, 
                      @Attribute, 
                      @Op, 
                      @Value);
                      SELECT
                      `Id`
                      FROM `radcheck`
                       WHERE  row_count() > 0 AND `Id`=last_insert_id();"
            );
            
            CreateStoredProcedure(
                "dbo.User_Update",
                p => new
                    {
                        Id = p.Int(),
                        UserName = p.String(maxLength: 64, unicode: false),
                        Attribute = p.String(maxLength: 64, unicode: false),
                        Op = p.String(maxLength: 2, unicode: false),
                        Value = p.String(maxLength: 253, unicode: false),
                    },
                body:
                    @"UPDATE `radcheck` SET `UserName`=@UserName, `Attribute`=@Attribute, `Op`=@Op, `Value`=@Value WHERE `Id` = @Id;"
            );
            
            CreateStoredProcedure(
                "dbo.User_Delete",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE FROM `radcheck` WHERE `Id` = @Id;"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.User_Delete");
            DropStoredProcedure("dbo.User_Update");
            DropStoredProcedure("dbo.User_Insert");
            DropStoredProcedure("dbo.UserGroup_Delete");
            DropStoredProcedure("dbo.UserGroup_Update");
            DropStoredProcedure("dbo.UserGroup_Insert");
            DropStoredProcedure("dbo.UserAttribute_Delete");
            DropStoredProcedure("dbo.UserAttribute_Update");
            DropStoredProcedure("dbo.UserAttribute_Insert");
            DropStoredProcedure("dbo.Nas_Delete");
            DropStoredProcedure("dbo.Nas_Update");
            DropStoredProcedure("dbo.Nas_Insert");
            DropStoredProcedure("dbo.Group_Delete");
            DropStoredProcedure("dbo.Group_Update");
            DropStoredProcedure("dbo.Group_Insert");
            DropStoredProcedure("dbo.GroupAttribute_Delete");
            DropStoredProcedure("dbo.GroupAttribute_Update");
            DropStoredProcedure("dbo.GroupAttribute_Insert");
            DropStoredProcedure("dbo.AccessLog_Delete");
            DropStoredProcedure("dbo.AccessLog_Update");
            DropStoredProcedure("dbo.AccessLog_Insert");
            DropIndex("dbo.radcheck", "username");
            DropIndex("dbo.radusergroup", "username");
            DropIndex("dbo.radreply", "username");
            DropIndex("dbo.nas", "NasName");
            DropIndex("dbo.radgroupcheck", "groupname");
            DropIndex("dbo.radgroupreply", "groupname");
            DropIndex("dbo.radacct", "framedipaddress");
            DropIndex("dbo.radacct", "acctinterval");
            DropIndex("dbo.radacct", "acctstoptime");
            DropIndex("dbo.radacct", "acctstarttime");
            DropIndex("dbo.radacct", "nasipaddress");
            DropIndex("dbo.radacct", "username");
            DropIndex("dbo.radacct", "acctuniqueid");
            DropIndex("dbo.radacct", "acctsessionid");
            DropTable("dbo.radcheck");
            DropTable("dbo.radusergroup");
            DropTable("dbo.radreply");
            DropTable("dbo.nas");
            DropTable("dbo.radgroupcheck");
            DropTable("dbo.radgroupreply");
            DropTable("dbo.radacct");
        }
    }
}
