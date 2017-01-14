<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>ファイルのデータをまとめて表示する</title>
</head>
<body>
	<?php
		$file_name = "test2.txt";
		$file = fopen($file_name, "r") or die("OPEN エラー $file_name");
		$string = fread($file, filesize($file_name));
		echo "<p>ファイルの内容: ".$string."</p>";
		fclose($file);

		$string = file_get_contents($file_name);
		echo "<p>ファイルの内容: ".$string."</p>";

		$string = file($file_name);
		echo "<p>ファイルの内容:";
		print_r($string);
	?>
</body>
</html>