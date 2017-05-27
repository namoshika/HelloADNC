<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<?php session_start(); ?>
	<title>簡易アンケート v.1.0</title>
</head>
<body>
	<center><font color="blue" size="5">簡易アンケート v.1.0</font></center>
	<br /><br />

	<p>
		これまでアンケートに答えたのは<?php echo $_SESSION["total_cnt"]; ?>人です。そのうち<br />
		<?php
			$mal = $_SESSION["male"];
			$fem = $_SESSION["female"];
		?>
		男性：<?php echo $mal ?>人<?php echo $mal / ($mal + $fem)*100; ?>%<br />
		女性：<?php echo $fem ?>人<?php echo $fem / ($mal + $fem)*100; ?>%<br />
	</p>
	<p>
		好きな果物は<br />
		いちご：<?php echo $_SESSION["strawberry"]; ?>人、
		みかん：<?php echo $_SESSION["orange"]; ?>人、
		すいか：<?php echo $_SESSION["watermelon"]; ?>人、
		メロン：<?php echo $_SESSION["melon"]; ?>人、
		バナナ：<?php echo $_SESSION["banana"]; ?>人
	</p>
	<p>
		趣味は<br />
		映画：<?php echo $_SESSION["hobby"][0]; ?>人、
		音楽：<?php echo $_SESSION["hobby"][1]; ?>人、
		読書：<?php echo $_SESSION["hobby"][2]; ?>人、
		スポーツ：<?php echo $_SESSION["hobby"][3]; ?>人、
	</p>
	<p>
		出身の地域は<br />
		北海道：<?php echo $_SESSION["region"][0]; ?>人、
		東京：<?php echo $_SESSION["region"][1]; ?>人、
		京都：<?php echo $_SESSION["region"][2]; ?>人
	</p>
	<p>
		意見:<br />
		<?php
			foreach($_SESSION["comment"] as $idx => $val){
				echo $val."<br />";
			}
		?>
	</p>
	<br /><br />
	集計を<a href="03_questionnaire_reset.php">初期化する</a><br />
	さらに<a href="01_questionnaire.php">入力する</a>
</body>
</html>