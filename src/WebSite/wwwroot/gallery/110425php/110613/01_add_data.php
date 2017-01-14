<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>ファイルにデータを書き込む(追記)</title>
</head>
<body>
	<?php
		$file_name = "test1.txt";
		$file = fopen($file_name, "a") or die("OPEN エラー $file_name");

		flock($file, LOCK_EX);
		$string = "test1: ファイルをオープンして文字列を書き込みます\n";

		fputs($file, $string);
		flock($file, LOCK_UN);
		fclose($file);
	?>
</body>
</html>