<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<title>住所録登録</title>
</head>
<body>
	<?php
	$url = "db2.ne.senshu-u.ac.jp";
	$user = "webprog13";
	$pass = "tokushu2011";
	$db = "webprog13";

	extract($_POST);
	mysql_connect($url, $user, $pass) or die("データベースの接続に失敗しました");
	mysql_select_db($db) or die("データベースの選択に失敗しました");

	$kyou = date("y-m-d");
	$sql = "insert into jushoroku values(0, '$kyou', '$nam', '$yu1', '$yu2', '$ju1', '$ju2', '$tel', '$fax', '$kei', '$mai', '$bik')";
	mysql_query($sql);

	?>
</body>
</html>