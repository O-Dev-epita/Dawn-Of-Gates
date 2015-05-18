<?php

	$limitDate = time() - 1500;

	$bdd = new PDO('mysql:host=localhost;dbname=dog;charset=utf8', 'root', '');

	$req = $bdd->prepare('DELETE FROM connections WHERE date < ?');
	$req->execute(array($limitDate));

	$req = $bdd->prepare('SELECT * FROM connections WHERE player != ?');
	$req->execute(array($_POST['pseudo']));

	while($data = $req->fetch())
	{
		echo $data["player"] . ";" . $data["ip"] . ";";
	}

	

?>