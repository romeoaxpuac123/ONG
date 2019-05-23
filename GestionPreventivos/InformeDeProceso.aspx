<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InformeDeProceso.aspx.cs" Inherits="GestionPreventivos.InformeDeProceso" %>

<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<script src="//maxcdn.bootstrapcdn.com/bootstrap/4.1.1/js/bootstrap.min.js"></script>
<script src="//cdnjs.cloudflare.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
<!------ Include the above in your HEAD tag ---------->

<!DOCTYPE html>
<html>
<head>
	<title>REGISTRO DELITO</title>
   <!--Made with love by Mutiullah Samim -->
   
	<!--Bootsrap 4 CDN-->
	<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.1.3/css/bootstrap.min.css" integrity="sha384-MCw98/SFnGE8fJT3GXwEOngsV7Zt27NXFoaoApmYm81iuXoPkFOJwJ8ERdknLPMO" crossorigin="anonymous">
    
    <!--Fontawesome CDN-->
	<link rel="stylesheet" href="https://use.fontawesome.com/releases/v5.3.1/css/all.css" integrity="sha384-mzrmE5qonljUremFsqc01SB46JvROS7bZs3IO2EmfFsd15uHvIt+Y8vEf7N7fWAU" crossorigin="anonymous">

	<!--Custom styles-->
	<link rel="stylesheet" type="text/css" href="Styles3.css">
</head>
<body>
<div class="container">
	<div class="d-flex justify-content-center h-100">
		<div class="card">
			<div class="card-header">
				<h3>INFORME PROCESO</h3>
                <!--
				<div class="d-flex justify-content-end social_icon">
					<span><i class="fab fa-facebook-square"></i></span>
					<span><i class="fab fa-google-plus-square"></i></span>
					<span><i class="fab fa-twitter-square"></i></span>
				</div>
                    -->
			</div>
		<div class="card-body">
				<form id="form1" runat="server">
					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-user"></i></span>
						</div>
                        <asp:TextBox type="text" class="form-control" placeholder="PRIVADO" autocomplete="off" ID="TextBox1" runat="server" Style="text-transform: uppercase"></asp:TextBox>
						
					</div>

                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
                         <asp:ListBox  rows= 1 type="text" class="form-control" ID="ListBox1" runat="server" autocomplete="off" Style="text-transform: uppercase" DataSourceID="SqlDataSource1" DataTextField="NOMBRE_DELITO" DataValueField="NOMBRE_DELITO" ></asp:ListBox>
					    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BDONGConnectionString %>" SelectCommand="SELECT [NOMBRE_DELITO] FROM [DELITOS]"></asp:SqlDataSource>
					</div>

					<div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="EXPEDIENTE" autocomplete="off" ID="TextBox2" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>

                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="EJECUTORIA" autocomplete="off" ID="TextBox3" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>
                   
                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="JUZGADO" autocomplete="off" ID="TextBox4" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>        
                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="SALA" autocomplete="off" ID="TextBox5" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>  
                    
                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="PRISION AÑOS" autocomplete="off" ID="TextBox6" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>

                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="MULTA" autocomplete="off" ID="TextBox7" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>

                    <div class="input-group form-group">
						<div class="input-group-prepend">
							<span class="input-group-text"><i class="fas fa-edit"></i></span>
						</div>
						
					     <asp:TextBox type="text" class="form-control" placeholder="TIEMPO CUMPLIDO" autocomplete="off" ID="TextBox8" runat="server" Style="text-transform: uppercase"></asp:TextBox>
                    </div>

                         <div class="form-group">
						  <asp:Button type="submit" value="REGISTRO" class="btn float-right login_btn" ID="Button1" runat="server" Text="REGISTRO" OnClick="Button1_Click" />
					</div>
				</form>
			</div>
			
		</div>
	    <br />
	</div>
</div>
</body>
</html>
