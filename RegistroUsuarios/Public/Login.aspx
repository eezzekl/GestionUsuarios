<%@ Page Title="" Language="C#" MasterPageFile="~/masters/Publica.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="RegistroUsuarios.Public.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdnjs.cloudflare.com/ajax/libs/mdb-ui-kit/6.3.1/mdb.min.css" rel="stylesheet"/>
    <title>Login </title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="formcontent">
        <form id="formLogin" runat="server">
            <div class="form-control">
                <div class="col-md-10 col d-flex align-items-center">
                    <div class="card-body p-4 p-lg-5 text-black">

                        <div class="d-flex align-items-center mb-3 pb-1">
                            <i class="fas fa-cubes fa-2x me-3" style="color: #ff6219;"></i>
                            <span class="h1 fw-bold mb-0">Logo</span>
                        </div>

                        <h5 class="fw-normal mb-3 pb-3" style="letter-spacing: 1px;">Iniciar Sesion</h5>

                        <div class="form-outline mb-4">
                            <asp:TextBox ID="txtUsuario" CssClass="form-control form-control-lg" runat="server"></asp:TextBox>
                            <asp:Label ID="lblUsuario" CssClass="form-label" for="txtUsuario" runat="server" Text="Usuario: "></asp:Label>
                        </div>

                        <div class="form-outline mb-4">
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control form-control-lg" ></asp:TextBox>
                            <asp:Label ID="lblPasssword" CssClass="form-label" runat="server" Text="Password"></asp:Label>
                        </div>
                        <hr />
                        <div class="row">
                            <asp:Label runat="server" id="lblError" CssClass="alert alert-danger"></asp:Label>
                        </div>

                        <div class="pt-1 mb-4">
                            <asp:Button ID="btnIngresar" runat="server" Text="Login" CssClass="btn btn-dark btn-lg btn-block" OnClick="BtnIngresar_Click" />
                        </div>

                        <p class="mb-5 pb-lg-2" style="color: #393f81;">
                            <a href="Registro.aspx" style="color: #393f81;">Registrate Aquí  </a>
                        </p>

                    </div>
                </div>
                <!-- --- --- --- -- ---- --- --- --- --- -->
                <div>
                </div>

            </div>
        </form>
    </div>
</asp:Content>
