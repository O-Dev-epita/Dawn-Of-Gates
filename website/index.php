<?php

	session_start();

	if(!isset($_POST['game']))
	{

?>

<!DOCTYPE HTML>
<html>
	<head>
		<title>Dawn Of Gates</title>
		<meta http-equiv="content-type" content="text/html; charset=utf-8" />
		<!--[if lte IE 8]><script src="css/ie/html5shiv.js"></script><![endif]-->
		<script src="js/jquery.min.js"></script>
		<script src="js/jquery.dropotron.min.js"></script>
		<script src="js/skel.min.js"></script>
		<script src="js/skel-layers.min.js"></script>
		<script src="js/init.js"></script>
		<noscript>
			<link rel="stylesheet" href="css/skel.css" />
			<link rel="stylesheet" href="css/style.css" />
			<link rel="stylesheet" href="css/style-desktop.css" />
		</noscript>
		<!--[if lte IE 8]><link rel="stylesheet" href="css/ie/v8.css" /><![endif]-->
	</head>
	<body class="homepage">

		<!-- Header -->
			<div id="header-wrapper" class="wrapper">
				<div id="header">
					
					<!-- Logo -->
						<div id="logo">
							<h1><a href="index.html">Dawn Of Gates</a></h1>
							<p>Un jeu d'action sur Oculus par O_Dev</p>
						</div>
					
					<!-- Nav -->
						<nav id="nav">
							<ul>
								<li><a href="index.php">Accueil</a></li>
								<li><a href="index.php?page=scores">Scores</a></li>
								<li><a href="index.php?page=downloads">Téléchargements</a></li>
								<li><a href="index.php?page=presentation">Présentation</a></li>
								<li><a href="index.php?page=links">Liens</a></li>

								<?php

									if(isset($_SESSION["pseudo"]))
									{
										echo "<li>Connecté (" . $_SESSION["pseudo"] . ")</li>";
										echo '<li><a href="index.php?page=signout">Déconnection</a></li>';
									}
									else
									{
										echo '<li><a href="index.php?page=signin">Connection</a></li>';
										echo '<li><a href="index.php?page=signup">Inscription</a></li>';
									}

								?>

							</ul>
						</nav>

				</div>
			</div>

			<?php

				}

				if(!isset($_GET['page']))
				{
					include('index_body.php');
				}
				else
				{
					$page = $_GET['page'];
					if($page == 'scores')
					{
						include('scores/get.php');
					}
					else if($page == 'downloads')
					{
						include('downloads.php');
					}
					else if($page == 'presentation')
					{
						include('presentation.php');
					}
					else if($page == 'links')
					{
						include('links.php');
					}
					else if($page == 'signout')
					{
						include("members/signout.php");
					}
					else if($page == 'signin')
					{
						include("members/signin.php");
					}
					else if($page == 'signup')
					{
						include("members/signup.php");
					}
					else
					{
						include('error.php');
					}
				}

				if(!isset($_POST['game']))
				{

			?>

			<div id="footer-wrapper" class="wrapper">
				<div id="footer" class="container">
					
				<div id="copyright">
					<ul>
						<li>&copy; O_Dev</li><li>Design: <a href="http://html5up.net">HTML5 UP</a></li>
					</ul>
				</div>
			</div>

	</body>
</html>

<?php

}

?>