<%@ Page Title="" Language="C#" MasterPageFile="~/masters/Intra.Master" AutoEventWireup="true" CodeBehind="CRUD.aspx.cs" Inherits="RegistroUsuarios.Intra.CRUD" EnableEventValidation="true" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="body" runat="server">
    <br />
    <div class="container">
        <div class="mx-auto text-center">
            <div class="col-6 offset-3">
                <h1>
                    <asp:Label ID="lblTitulo" runat="server"></asp:Label></h1>
            </div>
        </div>
        <div class="container">

            <div class="row">
                <div class="col-6 offset-3">

                    <fieldset>
                        <legend>Datos Personales</legend>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblCorreo" runat="server" Text="Correo: " for="txtCorreo"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" placeholder="email" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblSexo" runat="server" Text="Sexo" for="ddlSexo"  Enabled="false"></asp:Label>
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
                                <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control" placeholder="Usuario"  Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblPswd" runat="server" Text="Contraseña" for="txtPswd"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtPswd" TextMode="Password" runat="server" CssClass="form-control" placeholder="Contraseña"  Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row" id ="dvconContra" visible="true" runat="server">
                            <div class="col">
                                <asp:Label ID="lblConfPwd" runat="server" Text="Confirmar Contraseña" for="txtConfPswd"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtConfPswd" TextMode="Password" runat="server" CssClass="form-control" placeholder="ConfirmaContraseña"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                    <br />
                    <fieldset id="fsInformativos" runat="server" visible="false">
                        <legend>Datos Informativos</legend>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblEstatus" runat="server" Text="Estatus: " for="txtEstatus"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtEstatus" runat="server" CssClass="form-control" placeholder="Estatus" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <asp:Label ID="lblFCreacion" runat="server" Text="Fecha Creacion: " for="txtFCreacion"></asp:Label>
                            </div>
                            <div class="col">
                                <asp:TextBox ID="txtFCreacion" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                            </div>
                        </div>
                    </fieldset>
                    <br />
                    <div class="row">
                        <asp:Label runat="server" ID="lblError" CssClass="alert alert-danger" Visible="false"></asp:Label>
                    </div>
                    <br />
                    <div>
                        <asp:Button ID="BtnCreate" runat="server" Text="Crear" CssClass="btn btn-success btn-primary" OnClick="BtnCreate_Click" Visible="false" />
                        <asp:Button ID="BtnUpdate" runat="server" Text="Actualizar" CssClass="btn btn-success btn-primary" OnClick="BtnUpdate_Click" Visible="false" />
                        <asp:Button ID="BtnDelete" runat="server" Text="Eliminar" CssClass="btn btn-success btn-primary" OnClick="BtnDelete_Click" Visible="false" />
                        <asp:Button ID="BtnRegresar" runat="server" Text="Regresar" CssClass="btn btn-success btn-dark" OnClick="BtnRegresar_Click" />
                    </div>
                    <br />
                    <div class="row">
                        <asp:Label runat="server" ID="lblExito" CssClass="alert alert-success" Visible="false"></asp:Label>
                    </div>

                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="CPScripts" runat="server">
    <script type="text/javascript" src="../Recursos/JS/Validaciones.js"></script>
</asp:Content>
