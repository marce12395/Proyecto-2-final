<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="Proyecto_2_final.inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="css/estilo.css" rel="stylesheet" />
    <style type="text/css">
        .login-box {
            height: 424px;
            width: 530px;
        }
        .crear {
            height: 101px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
         <div class="login-box">

             <h2>Gestión de Usuarios</h2>

<!-- Usuario -->
<label>Usuario (correo):</label>
<asp:TextBox ID="tusuario" runat="server"></asp:TextBox>

<!-- Contraseña -->
<label>Contraseña:</label>
<asp:TextBox ID="tclave" runat="server" TextMode="Password"></asp:TextBox>

<!-- Nombre -->
<label>Nombre:</label>
<asp:TextBox ID="tnombre" runat="server"></asp:TextBox>
                         <asp:Button ID="bingresar" runat="server" CssClass="aspNetButton" 
                       Text="Ingresar" OnClick="bingresar_Click1"/>

            <asp:Button ID="bagregar" runat="server" CssClass="aspNetButton" 
                         Text="Agregar Usuario" OnClick="bagregar_Click" />

            <asp:Button ID="beliminar" runat="server" CssClass="aspNetButton" 
                        Text="Eliminar Usuario" OnClick="beliminar_Click" />

            <!-- Mensaje -->
            <asp:Label ID="lblMensaje" runat="server" CssClass="aspNetLabel" Text=""></asp:Label>
        
        </div>

    </form>
</body>
</html>
