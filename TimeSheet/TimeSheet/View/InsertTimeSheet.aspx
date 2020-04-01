<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InsertTimeSheet.aspx.cs" Inherits="TimeSheet.View.InsertTimeSheet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-3"></div>
        <div class="col-6">
            <div class="card" style="width: 20rem;">
                <div class="card-header text-center">
                    <h3>Insert Time Sheet</h3>
                </div>
                <div class="card-body">
                    <div class="form-group">
                        <asp:Label Text="Project Id" runat="server" Font-Bold="true" />
                        <asp:TextBox runat="server" ID="txtProjectId" placeholder="Project Id" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Username" runat="server" Font-Bold="true" />
                        <asp:TextBox runat="server" ID="txtUsername" placeholder="Username" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Description" runat="server" Font-Bold="true" />
                        <asp:TextBox TextMode="MultiLine" ID="txtDes" placeholder="Description" CssClass="form-control" runat="server" Style="resize: none" />
                    </div>
                    <div class="form-group">
                        <asp:Label Text="Hours" runat="server" Font-Bold="true" />
                        <asp:DropDownList ID="ddlHours" CssClass="form-control" runat="server"></asp:DropDownList>
                    </div>
                    <asp:Button Text="Submit" runat="server" class="btn btn-primary" ID="btnSubmit" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
        <div class="col-3"></div>
    </div>
    <script type="text/javascript">
</script>
</asp:Content>
