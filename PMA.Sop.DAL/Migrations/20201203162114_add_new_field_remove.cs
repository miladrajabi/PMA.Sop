using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PMA.Sop.DAL.Migrations
{
    public partial class add_new_field_remove : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_Users_ApplicationUserId",
                table: "Wallet");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallet_WalletType_WalletTypeId",
                table: "Wallet");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletType",
                table: "WalletType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet");

            migrationBuilder.RenameTable(
                name: "WalletType",
                newName: "WalletTypes");

            migrationBuilder.RenameTable(
                name: "Wallet",
                newName: "Wallets");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_WalletTypeId",
                table: "Wallets",
                newName: "IX_Wallets_WalletTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wallet_ApplicationUserId",
                table: "Wallets",
                newName: "IX_Wallets_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "ApplicationUserInfos",
                type: "nchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ApplicationUserInfos",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ApplicationUserInfos",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "ApplicationUserInfos",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "ApplicationUserInfos",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientNationalCode",
                table: "ApplicationUserAddresses",
                type: "nchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientLastName",
                table: "ApplicationUserAddresses",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "RecipientIsSelf",
                table: "ApplicationUserAddresses",
                type: "bit",
                nullable: false,
                defaultValue: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<string>(
                name: "RecipientFirstName",
                table: "ApplicationUserAddresses",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostalAddress",
                table: "ApplicationUserAddresses",
                type: "nvarchar(350)",
                maxLength: 350,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "ApplicationUserAddresses",
                type: "nchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "ApplicationUserAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "ApplicationUserAddresses",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wallets",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsRemoved",
                table: "Wallets",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RemoveTime",
                table: "Wallets",
                type: "DateTime",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTypes",
                table: "WalletTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Users_ApplicationUserId",
                table: "Wallets",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeId",
                table: "Wallets",
                column: "WalletTypeId",
                principalTable: "WalletTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Users_ApplicationUserId",
                table: "Wallets");

            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_WalletTypes_WalletTypeId",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTypes",
                table: "WalletTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "ApplicationUserInfos");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "ApplicationUserInfos");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "ApplicationUserAddresses");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "ApplicationUserAddresses");

            migrationBuilder.DropColumn(
                name: "IsRemoved",
                table: "Wallets");

            migrationBuilder.DropColumn(
                name: "RemoveTime",
                table: "Wallets");

            migrationBuilder.RenameTable(
                name: "WalletTypes",
                newName: "WalletType");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "Wallet");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_WalletTypeId",
                table: "Wallet",
                newName: "IX_Wallet_WalletTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Wallets_ApplicationUserId",
                table: "Wallet",
                newName: "IX_Wallet_ApplicationUserId");

            migrationBuilder.AlterColumn<string>(
                name: "NationalCode",
                table: "ApplicationUserInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "ApplicationUserInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "ApplicationUserInfos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientNationalCode",
                table: "ApplicationUserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientLastName",
                table: "ApplicationUserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<bool>(
                name: "RecipientIsSelf",
                table: "ApplicationUserAddresses",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldDefaultValue: true);

            migrationBuilder.AlterColumn<string>(
                name: "RecipientFirstName",
                table: "ApplicationUserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "PostalAddress",
                table: "ApplicationUserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(350)",
                oldMaxLength: 350,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostCode",
                table: "ApplicationUserAddresses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Wallet",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletType",
                table: "WalletType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallet",
                table: "Wallet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_Users_ApplicationUserId",
                table: "Wallet",
                column: "ApplicationUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wallet_WalletType_WalletTypeId",
                table: "Wallet",
                column: "WalletTypeId",
                principalTable: "WalletType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
