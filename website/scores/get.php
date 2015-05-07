<div class="wrapper style2">
	<div class="title">Scores</div>
	<div id="main" class="container">

		<?php

			$scores = unserialize(file_get_contents("scores/scores.data"));

			for($i = 0; $i < count($scores); $i++)
			{
				?>

					<section class="highlight">
						<h3>Niveau <?php echo $i+1; ?></h3>
						<ul>
							<li>Premier: <?php if($scores[$i][0] != -1) { echo $scores[$i][0] . 's'; } ?></li>
							<li>Second: <?php if($scores[$i][1] != -1) { echo $scores[$i][1] . 's'; } ?></li>
							<li>Troisième: <?php if($scores[$i][2] != -1) { echo $scores[$i][2] . 's'; } ?></li>
							<li>Quatrième: <?php if($scores[$i][3] != -1) { echo $scores[$i][3] . 's'; } ?></li>
							<li>Cinquième: <?php if($scores[$i][4] != -1) { echo $scores[$i][4] . 's'; } ?></li>
						</ul>
					</section>	

				<?php
			}

		?>

		
					
				
	</div>
</div>