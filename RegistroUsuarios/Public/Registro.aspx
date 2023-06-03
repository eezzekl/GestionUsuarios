<%@ Page Title="" Language="C#" MasterPageFile="~/masters/Publica.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="RegistroUsuarios.Public.Registro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Registrarse</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-6 offset-3">
                <form id="frmRegistro" runat="server" class="">
                    <fieldset>
                        <legend>Datos Personales</legend>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblCorreo" runat="server" Text="Correo: " for="txtCorreo"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblSexo" runat="server" Text="Sexo" for="ddlSexo"></asp:Label>
                            </div>
                            <div class="col text-left">
                                <asp:DropDownList ID="ddlSexo" runat="server" CssClass="btn btn-secondary dropdown-toggle show">
                                    <asp:ListItem Value="Masculino" Text="Masculino" CssClass="dropdown-item"></asp:ListItem>
                                    <asp:ListItem Value="Femenino" Text="Femenino" CssClass="dropdown-item"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </fieldset>
                    <br />
                    <fieldset>
                        <legend>Datos de Login</legend>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblUsuario" runat="server" Text="Usuario" for="txtUsuario"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPswd" runat="server" Text="Contraseña" for="txtPswd"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtPswd" TextMode="Password" runat="server" CssClass="form-control" placeholder="Contraseña"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblConfPwd" runat="server" Text="Contraseña" for="txtConfPswd"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtConfPswd" TextMode="Password" runat="server" CssClass="form-control" placeholder="ConfirmaContraseña"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                    <br />
                    <div class="row">
                        <asp:Label runat="server" ID="lblError" CssClass="alert alert-danger"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="BtnRegistrar" runat="server" Text="Registrar" CssClass="btn btn-success btn-primary" OnClick="BtnRegistrar_Click" />
                    </div>
                    <div class="row">
                        <asp:Label runat="server" ID="lblExito" CssClass="alert alert-success"></asp:Label>
                    </div>
                </form>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPScripts" runat="server">
</asp:Content>
