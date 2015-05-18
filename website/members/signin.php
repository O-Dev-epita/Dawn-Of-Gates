<?php

	if(isset($_POST['pseudo']) && isset($_POST['pass']))
	{

		$bdd = new PDO('mysql:host=localhost;dbname=dog;charset=utf8', 'root', '');

		$req = $bdd->prepare('SELECT id FROM accounts WHERE pseudo = ? AND password = ?');
		$req->execute(array($_POST['pseudo'], $_POST['pass']));

		$data = $req->fetch();
		if($data)
		{

			if(isset($_POST['game']))
			{
				echo $data['id'];

				$req = $bdd->prepare('INSERT INTO connections(player, ip, date) VALUES(?, ?, ?)');
				$req->execute(array(
					$_POST['pseudo'],
					$_SERVER['REMOTE_ADDR'],
					time()
				));



			}
			else
			{
				$_SESSION['pseudo'] = $_POST['pseudo'];
				$_SESSION['id'] = $data['id'];
				include("members/signin_done.php");
			}



		}
		else
		{

			if(isset($_POST['game']))
			{
				echo "-1";
			}
			else
			{
				$error = true;
				include("members/signin_form.php");
			}
		}

		$req->closeCursor();


	}
	else
	{
		$error = false;
		include("members/signin_form.php");
	}

?>