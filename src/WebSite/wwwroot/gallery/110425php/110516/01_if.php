<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<title>if文で条件分岐する</title>
</head>
<body>
	<?php
		$numA = 100;
		$numB = 100;

		if($numA == $numB){
			echo "2つの数値は等しい<br />";
		}

		$numB = 10;
		if($numA != $numB){
			echo "2つの数値は等しくない<br />";
		}

		$numA = 10;
		$numB = 100;
		if($numA > $numB){
			echo "number1はnumber2より大きい<br />";
		}else{
			echo "number1はnumber2より大きくない<br />";
		}

		if($numA == $numB){
			echo "number1とnumber2は等しい<br />";
		}else if($numA > $numB){
			echo "number1はnumber2より大きくない<br />";
		}else{
			echo "number1はnumber2より大きくない<br />";
		}
	?>
</body>
</html>