<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="TimeSheet.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col" style="padding-top: 20px">
            <asp:GridView ID="gvSheet" BorderWidth="0" GridLines="None" runat="server" AutoGenerateColumns="false" CssClass="table">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="ProjectId" HeaderText="Project Id" />
                    <asp:BoundField DataField="Username" HeaderText="Username" />
                    <asp:BoundField DataField="Description" HeaderText="Description" />
                    <asp:BoundField DataField="Hours" HeaderText="Hours" />
                    <asp:BoundField DataField="CreatedDate" HeaderText="Created Date" />
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
