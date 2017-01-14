<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>switch文で条件分岐する</title>
</head>
<body>
	<?php
	$num = rand(0,3);
	switch($num){
		case 0:
			echo "大吉";
			break;
		case 1:
			echo "中吉";
			break;
		case 2:
			echo "中吉";
			break;
		case 3:
			echo "凶";
			break;
	}
	?>
</body>
</html>