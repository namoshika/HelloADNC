<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<link rel="stylesheet" href="order_style.css" />
	<title>商品注文画面 v00</title>
	<?php
	//定義
	class ProductClass{
		public function __construct($name, $price){
			$this->name = $name;
			$this->price = $price;
		}
		public $name;
		public $price;
	}
	function loadProductsFile($path){
		$prdctsTxt = file_get_contents("products.txt");
		$prdctsAry = explode("\n", $prdctsTxt);
		$productObjAry = array();
		foreach($prdctsAry as $val){
			$splitAry = explode("&", $val);
			$productObjAry[] = new ProductClass($splitAry[0], $splitAry[1]);
		}
		return $productObjAry;
	}
	?>
</head>
<body>
	<h1>商品注文画面</h1>
	<form method="post" action="02_order_confirm.php">
		<div class="orderparam">
			<h2>商品を選択してください</h2>
			<select name="item">
				<?php
				$productObjs = loadProductsFile('products.txt');
				foreach($productObjs as $idx => $val){
					echo "<option value=\"{$idx}\">{$val->name}({$val->price})</option>\n";
				}
				?>
			</select>
		</div>
		<div class="orderparam">
			<h2>お名前</h2>
			<input type="text" name="namae" />
		</div>
		<div class="orderparam">
			<h2>送付先</h2>
			<input type="text" name="itemtarget" />
		</div>
		<div class="orderparam">
			<h2>配送の希望時間</h2>
			<ul class="listup hori">
				<li><input type="radio" name="hopetime" value="0">午前</li>
				<li><input type="radio" name="hopetime" value="1">午後</li>
				<li><input type="radio" name="hopetime" value="2">夜間</li>
			</ul>
		</div>
		<div class="orderparam">
			<h2>オプション</h2>
			<ul class="listup">
				<li><input type="checkbox" name="options[]" value="forpresent">贈り物用包装希望</li>
			</ul>
		</div>
		<div class="orderparam">
			<h2>他に希望があればお書きください</h2>
			<textarea name="comment" rows="5" cols="30">佐川急便はやめろ</textarea><br />
		</div>
		<input type="submit" name="button1" value="送信" />
		<input type="reset" />
	</form>
</body>
</html>