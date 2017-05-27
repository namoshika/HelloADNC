<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.01 Frameset//EN">
<html>
<head>
	<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
	<meta http-equiv="X-UA-Compatible" content="IE=100">
	<link rel="stylesheet" href="order_style.css" />
	<title>商品注文画面 v00</title>

	<?php
	//定義
	class OrderClass{
		public function __construct($itemId, $name, $sendAddress, $recievableTimeId, $isForPresent, $comment){
			$this->itemId = $itemId;
			$this->name = $name;
			$this->sendAddress = $sendAddress;
			$this->recievableTimeId = $recievableTimeId;
			$this->isForPresent = $isForPresent;
			$this->comment = $comment;
		}
		public $itemId;
		public $name;
		public $sendAddress;
		public $recievableTimeId;
		public $isForPresent;
		public $comment;
	}
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
	function loadOrdersFile($path){
		$orderObjAry = unserialize(file_get_contents("orders.txt"));
		if($orderObjAry === null){
			$orderObjAry = array();
		}
		return $orderObjAry;
	}
	function saveOrdersFile($path, $orderObjAry){
		file_put_contents($path, serialize($orderObjAry));
	}

	//処理
	session_start();

	//注文ログを読み込む
	$ordersObjAry = loadOrdersFile("orders.txt");
	//注文をインスタンス化する
	if($_POST["item"] !== null && $_POST["namae"] !== null && $_POST["itemtarget"] !== null
	&& $_POST["hopetime"] !== null){

		$orderObj = new OrderClass(
			$_POST["item"], $_POST["namae"], $_POST["itemtarget"], $_POST["hopetime"],
			$_POST["options"][0] === "forpresent", (string)$_POST["comment"]);
		$ordersObjAry[] = $orderObj;
	}else{
		$orderObj = null;
	}
	//注文ログを更新
	saveOrdersFile("orders.txt", $ordersObjAry);
	?>
</head>
<body>
	<h1>商品注文画面</h1>
	<p>現在、以下の入力内容となっております。お間違いないでしょうか</p>
	<div class="orderparam">
		<h2>商品</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				$productObjs = loadProductsFile('products.txt');
				echo $productObjs[$orderObj->itemId]->name;
			}
			?>
		</p>
	</div>
	<div class="orderparam">
		<h2>お名前</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				echo $orderObj->name;
			}
			?>
		</p>
	</div>
	<div class="orderparam">
		<h2>送付先</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				echo $orderObj->sendAddress;
			}
			?>
		</p>
	</div>
	<div class="orderparam">
		<h2>配送の希望時間</h2>
		<?php
		if($orderObj == null){
			echo "Error";
		}else{
			switch($orderObj->recievableTimeId){
				case 0:
					echo "午前";
					break;
				case 1:
					echo "午後";
					break;
				case 2:
					echo "夜間";
					break;
			}
		}
		?>
	</div>
	<div class="orderparam">
		<h2>オプション</h2>
		<ul class="listup">
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				if($orderObj->isForPresent == true){
					echo "贈り物用包装希望";
				}else{
					echo "無し";
				}
			}
			?>
		</ul>
	</div>
	<div class="orderparam">
		<h2>他のご希望</h2>
		<p>
			<?php
			if($orderObj == null){
				echo "Error";
			}else{
				echo $orderObj->comment;
			}
			?>
		</p>
	</div>
	<a href="01_order.php">さらに注文する</a><br />
	<a href="03_order_total.php">注文した全商品を見る</a>
</form>
</body>
</html>