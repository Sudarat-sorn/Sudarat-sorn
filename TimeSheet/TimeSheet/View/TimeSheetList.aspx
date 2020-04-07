<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TimeSheetList.aspx.cs" Inherits="TimeSheet.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top: 20px">
            <asp:Button ID="btnQuery" runat="server" onclick="btnQuery_Click" text="Query" CssClass="btn btn-primary"/><br /><br />
            <asp:GridView ID="gvSheet" BorderWidth="0" GridLines="None" runat="server" CssClass="table">
            </asp:GridView>
            <asp:Label id="lblText" runat="server"></asp:Label>
        </div>
    </div>
</asp:Content>
