<div class="wrapper style2">
	<div class="title">Connection</div>
		<div id="main" class="container">
			<section class="highlight">

				<?php

					if($error)
					{
						echo "<div>Connection refusée : identifiants incorrects</div>";
					}

				?>

				<form method="post">
					
					<label for="pseudo">Pseudo</label>
					<input type="text" name="pseudo" id="pseudo" />

					<label for="pass">Mot de passe</label>
					<input type="password" name="pass" id="pass" />

					<input type="submit" value="Se connecter" />

				</form>
				 
			</section>
							
		</div>
	</div>
</div>