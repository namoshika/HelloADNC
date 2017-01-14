<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>ファイルのデータを表示する</title>
</head>
<body>
	<?php
		$file_name = "test1.txt";
		$file = fopen($file_name, "r") or die("OPEN エラー $file_name");

		flock($file, LOCK_SH);
		$string = "test1: ファイルをオープンして文字列を書き込みます\n";

		while (!feof($file)){
			$string = fgets($file, 1000);
			echo $string."<br />";
		}

		flock($file, LOCK_UN);
		fclose($file);
	?>
</body>
</html>