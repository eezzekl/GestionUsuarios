<%@ Page Title="" Language="C#" MasterPageFile="~/masters/Intra.master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RegistroUsuarios.Intra.index" %>

<asp:Content ID="cdHead" ContentPlaceHolderID="head" runat="server">
    <title>Index</title>
    <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/bootstrap-icons@1.10.5/font/bootstrap-icons.css">
</asp:Content>

<asp:Content ID="cdBody" ContentPlaceHolderID="body" runat="server">
    
        <div class="mx-auto text-center" >
            <h1>Listado de Usuarios</h1>
            <hr />
            <h2>Bienvenido al sistema</h2>
        </div>
        <div class="container">
            <div class="row justify-content-end"">
                <div class="col-3">
                    <asp:Button ID="BtnCreate" runat="server" Text="Create" CssClass="btn btn-success form-control" OnClick="BtnCreate_Click"  />
                </div>
            </div>
        </div>
        <br />
        <div class="container row">
            <div class="table small">
                <asp:GridView runat="server" ID="gvusuarios" class="table table-borderless table-hover" >
                     <Columns>
                        <asp:TemplateField HeaderText="Opciones del administrador">
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Read" CssClass="btn form-control-sm btn-info" ID="BtnRead" OnClick="BtnRead_Click"/>
                                <asp:Button runat="server" Text="Update" CssClass="btn form-control-sm btn-warning" ID="BtnUpdate" OnClick="BtnUpdate_Click"/>
                                <!-- <i class="bi bi-pencil-square"></i> -->
                                <asp:Button runat="server" Text="Delete" CssClass="btn form-control-sm btn-danger" ID="BtnDelete" OnClick="BtnDelete_Click"/>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
        </div>
        <div>
            <asp:Button ID="BtnCerrar" runat="server" Text="Cerrar Sesion" OnClick="BtnCerrar_Click" CssClass="btn btn-secondary" />
        </div>
    
</asp:Content>
