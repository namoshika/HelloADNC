<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<?php session_start(); ?>
	<title>questionnaire_confirm.php</title>
</head>
<body>
	<center><font color="blue" size="5">簡易アンケート v.1.0</font></center>
	<br /><br />
	<?php
		echo "POST 変数表示<br />";
		foreach($_POST as $index => $value){
			echo "$index:$value<br />";
		}


		if($_POST["gender"] == 0){
			++$_SESSION["male"];
		}else{
			++$_SESSION["female"];
		}

		if($_POST["strawberry"]){
			++$_SESSION["strawberry"];
		}
		if($_POST["orange"]){
			++$_SESSION["orange"];
		}
		if($_POST["watermelon"]){
			++$_SESSION["watermelon"];
		}
		if($_POST["melon"]){
			++$_SESSION["melon"];
		}
		if($_POST["banana"]){
			++$_SESSION["banana"];
		}

		for($i = 0; $i < 3; $i++){
			if($_POST["hobby"][$i] == 1)
				++$_SESSION["hobby"][$i];
		}

		$_SESSION["region"][$_POST["region"]]++;

		$_SESSION["comment"][] = $_POST["comment"];
		++$_SESSION["total_cnt"];

		echo "SESSION 変数表示<br />";
		foreach($_SESSION as $idx => $val)
		{
			echo $idx."：".$val."<br />";
		}
	?>
	<br /><br />
	登録しました。さらに<a href="01_questionnaire.php">入力する</a><br />
	これまでの集計結果を<a href="04_questionnaire_total.php">表示する</a>
</body>
</html>