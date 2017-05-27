<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>ファイルをオープンせずにデータを書き込む</title>
</head>
<body>
	<?php
		$file_name = "test2.txt";
		$string = "test2: ファイルをオープンせずにデータを書き込む\n";

		file_put_contents($file_name, $string);
	?>
</body>
</html>