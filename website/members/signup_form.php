<div class="wrapper style2">
	<div class="title">Inscription</div>
		<div id="main" class="container">
			<section class="highlight">

				<?php

					if($error)
					{
						echo "<div>L'inscription a échouée: " . $error . "</div>";
					}

				?>

				<form method="post">
					
					<label for="pseudo">Pseudo</label>
					<input type="text" name="pseudo" id="pseudo" />

					<label for="pass1">Mot de passe</label>
					<input type="password" name="pass1" id="pass1" />

					<label for="pass2">Répéter le mot de passe</label>
					<input type="password" name="pass2" id="pass2" />

					<input type="submit" value="S'inscrire" />

				</form>
				 
			</section>
							
		</div>
	</div>
</div>