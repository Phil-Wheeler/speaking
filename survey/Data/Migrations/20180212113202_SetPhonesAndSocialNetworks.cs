using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace survey.Data.Migrations
{
    public partial class SetPhonesAndSocialNetworks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Phone_PhoneId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetwork_Responses_ResponseId",
                table: "SocialNetwork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialNetwork",
                table: "SocialNetwork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phone",
                table: "Phone");

            migrationBuilder.RenameTable(
                name: "SocialNetwork",
                newName: "SocialNetworks");

            migrationBuilder.RenameTable(
                name: "Phone",
                newName: "Phones");

            migrationBuilder.RenameIndex(
                name: "IX_SocialNetwork_ResponseId",
                table: "SocialNetworks",
                newName: "IX_SocialNetworks_ResponseId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SocialNetworks",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialNetworks",
                table: "SocialNetworks",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phones",
                table: "Phones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Phones_PhoneId",
                table: "Responses",
                column: "PhoneId",
                principalTable: "Phones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetworks_Responses_ResponseId",
                table: "SocialNetworks",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Responses_Phones_PhoneId",
                table: "Responses");

            migrationBuilder.DropForeignKey(
                name: "FK_SocialNetworks_Responses_ResponseId",
                table: "SocialNetworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SocialNetworks",
                table: "SocialNetworks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Phones",
                table: "Phones");

            migrationBuilder.RenameTable(
                name: "SocialNetworks",
                newName: "SocialNetwork");

            migrationBuilder.RenameTable(
                name: "Phones",
                newName: "Phone");

            migrationBuilder.RenameIndex(
                name: "IX_SocialNetworks_ResponseId",
                table: "SocialNetwork",
                newName: "IX_SocialNetwork_ResponseId");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "SocialNetwork",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_SocialNetwork",
                table: "SocialNetwork",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Phone",
                table: "Phone",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Responses_Phone_PhoneId",
                table: "Responses",
                column: "PhoneId",
                principalTable: "Phone",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SocialNetwork_Responses_ResponseId",
                table: "SocialNetwork",
                column: "ResponseId",
                principalTable: "Responses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
