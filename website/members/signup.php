<?php

	if(isset($_POST['pseudo']) && isset($_POST['pass1']) && isset($_POST['pass2']))
	{

		$bdd = new PDO('mysql:host=localhost;dbname=dog;charset=utf8', 'root', '');

		$req = $bdd->prepare('SELECT id FROM accounts WHERE pseudo = ?');
		$req->execute(array($_POST['pseudo']));

		$data = $req->fetch();

		if($data)
		{
			$error = "This pseudo already exists";
			if(isset($_POST['game']))
			{
				echo $error;
			}
			else
			{
				include("members/signup_form.php");	
			}

		}
		else
		{

			$req = $bdd->prepare('INSERT INTO accounts(pseudo, password, type) VALUES(:pseudo, :password, :type)');
			$req->execute(array(
				'pseudo' => $_POST['pseudo'],
				'password' => $_POST['pass1'],
				'type' => 0
			));

			if(isset($_POST['game']))
			{
				echo 'Ok';
			}
			else
			{
				include("members/signup_done.php");
			}

		}

		

	}
	else
	{
		$error = false;
		include("members/signup_form.php");
	}

?>