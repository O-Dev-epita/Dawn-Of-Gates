<?php

	if(isset($_GET['l']) && isset($_GET['t']))
	{
		$level = (int) $_GET['l'];
		$time = (int) $_GET['t'];

		$scores = unserialize(file_get_contents("scores.data"));

		$saved = false;

		for($i = 0; $i < count($scores[$level]) && !$saved; $i++)
		{

			if($scores[$level][$i] == -1 || $time < $scores[$level][$i])
			{
				for($j = count($scores[$level])-1; $j > $i; $j--)
				{
					$scores[$level][$j] = $scores[$level][$j-1];
				}
				$scores[$level][$i] = $time;
				$saved = true;
			}
		}

		file_put_contents("scores.data", serialize($scores));

		echo "ok";


	}
	else
	{
		echo "error";
	}

?>

