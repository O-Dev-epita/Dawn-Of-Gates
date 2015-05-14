<?php

	session_destroy();

?>

<div class="wrapper style2">
	<div class="title">Déconnection</div>
		<div id="main" class="container">
			<section class="highlight">
				 <p>Vous aviez bien été déconnecté, redirection en cours...</p>
			</section>
		</div>

		<script type="text/javascript">
			setTimeout(function() {
				window.location = "index.php";
			}, 3000);
		</script>

	</div>
</div>