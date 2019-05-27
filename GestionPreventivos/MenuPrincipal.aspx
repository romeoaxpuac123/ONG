<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MenuPrincipal.aspx.cs" Inherits="GestionPreventivos.MenuPrincipal" %>


<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<!DOCTYPE html>
<html>
<head>
	<title>MENU PRINCIPAL</title>
   <!--Made with love by Mutiullah Samim -->
   
	<!--Bootsrap 4 CDN-->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    
    <!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

	<!--Custom styles-->
	<link rel="stylesheet" type="text/css" href="Styles2.css">
</head>
<body>
<div class="container">
	<div class="d-flex justify-content-center h-100">
		<div class="card">
			<div class="card-header">
				<CENTER><h3>MENU</h3>
                <h3>PRINCIPAL</h3>
                </CENTER>
			</div>
            <CENTER>
		<div class="card-body">
				<form id="form1" runat="server">
			             					
					<div class="form-group">
						  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						  <asp:Button type="submit" value="REGISTRO" class="btn" ID="Button1" runat="server" OnClick="Button1_Click1" Text="REGISTRO PRIVADO" Height="57px" BackColor="#FFC312" Width="231px" />
					&nbsp;<asp:Button type="submit" value="REGISTRO" class="btn" ID="Button2" runat="server" Text="REGISTRO DELITO" Height="57px" BackColor="#FFC312" OnClick="Button2_Click" Width="229px" />
					      <br />
					&nbsp;<br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Button type="submit" value="REGISTRO" class="btn" ID="Button3" runat="server" Text="CENTRO PREVENTIVO" Height="57px" BackColor="#FFC312" OnClick="Button3_Click" Width="230px" />
					&nbsp;<asp:Button type="submit" value="REGISTRO" class="btn" ID="Button4" runat="server" Text="INFORME DE PROCESO" Height="57px" BackColor="#FFC312"  Width="228px" OnClick="Button4_Click" />
					      <br />
					      <br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Button type="submit" value="REGISTRO" class="btn" ID="Button5" runat="server" Text="BENEFICIO MAS CERCANO" Height="57px" BackColor="#FFC312"  Width="230px" OnClick="Button5_Click" />
					      &nbsp;<asp:Button type="submit" value="REGISTRO" class="btn" ID="Button6" runat="server" Text="OTRAS SOLICITUDES" Height="57px" BackColor="#FFC312"  Width="228px" OnClick="Button6_Click"  />
					      <br />
					      <br />
                          &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                          <asp:Button type="submit" value="REGISTRO" class="btn" ID="Button7" runat="server" Text="ESTADO DEL PROCESO" Height="57px" BackColor="#FFC312"  Width="230px" OnClick="Button7_Click"  />
					      &nbsp;<asp:Button type="submit" value="REGISTRO" class="btn" ID="Button8" runat="server" Text="BENEFICIADOS" Height="57px" BackColor="#FFC312"  Width="228px" OnClick="Button8_Click"  />
					      <br />
					</div>
				</form>
			</div>
			</CENTER>
		</div>
	    <br />
	</div>
</div>
</body>
</html>

