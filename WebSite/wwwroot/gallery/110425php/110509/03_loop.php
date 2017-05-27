<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>処理を繰り返す</title>
</head>
<body>
<?php
	echo "1～5までを表示する<br />\n";
	$i = 1;
	while($i <= 5){
		echo $i."の表示<br />\n";
		$i++;
	}

	for($i = 6; $i <=10; $i++){
		echo $i."の表示<br />\n";
	}

	//九九を表示する。
	for($x = 1; $x <= 9; $x++){
		for($y = 1; $y <= 9; $y++){
			echo $x."×".$y."=".($x * $y)."<br />\n";
		}
	}
?>
</body>
</html>