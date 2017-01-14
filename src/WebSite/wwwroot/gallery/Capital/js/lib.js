//----------------------
// クラスの類
//----------------------
//国情報コンテナと国情報クラス
function CountryContainer(xmlSource) {
	// Field Members
	this.items = new Array();

	// Construct
	var cntryEles = getChildNodesWithoutTextNode(xmlSource.firstChild);
	for ( var i = 0; i < cntryEles.length; i++) {
		var itemEles = getChildNodesWithoutTextNode(cntryEles[i]);
		this.items[this.items.length] = new CountryInfo(
				itemEles[0].textContent, itemEles[1].textContent,
				itemEles[2].textContent, itemEles[3].textContent,
				itemEles[4].textContent);
	}
}
function CountryInfo(name, capitalName, xpos, ypos, desc) {
	this.name = name;
	this.capitalName = capitalName;
	this.location = {
		latitude : xpos,
		longitude : ypos,
	};
	this.description = desc;
}

//地図コントローラー&首都名選択プルダウンメニューコントローラー&文章説明コントローラー
function MapController(element) {
	//fields
	var maker = null;
	var map = null;
	
	//methods
	//memo: プライベートメンバへアクセスするためにインラインメソッド化する
	this.setMarker = function(location, toolchip){
		if(maker != null){
			maker.setMap(null);
		}
		var latlng = new google.maps.LatLng(location.latitude, location.longitude);
		map.setCenter(latlng);
		maker = new google.maps.Marker({
			position: latlng,
			map: map,
			title: toolchip,
		});
	};
	
	//construct
	map = new google.maps.Map(element, {
		zoom : 6,
		center : new google.maps.LatLng(0, 0),
		mapTypeId : google.maps.MapTypeId.ROADMAP,
	});
}
function DescriptionController(element){
	//methods
	this.setDescription = function(item){
		if(element.firstChild == null){
			element.appendChild(document.createTextNode(item.description));
		}else{
			element.firstChild.nodeValue = item.description;
		}
	};
}
function PulldownController(selectElement, items, map, description) {
	//construct
	for ( var i = 0; i < items.length; i++) {
		var txtNd = document.createTextNode(items[i].name);
		var eleNd = document.createElement("option");
		eleNd.appendChild(txtNd);
		selectElement.appendChild(eleNd);
	}
	//mapもプルダウンメニューの状態と同期させる
	map.setMarker(items[0].location, items[0].capitalName);
	description.setDescription(items[0]);
	selectElement.addEventListener("change", function() {
		var item = items[selectElement.selectedIndex];
		map.setMarker(item.location, item.capitalName);
		description.setDescription(item);
	}, false);
}


//----------------------
// メソッドの類
//----------------------
function loadXml(url, callback) {
	var req = new XMLHttpRequest();
	req.onreadystatechange = function(status) {
		if (req.readyState == 4) {
			callback(req.status, req.responseXML);
		}
	};
	req.open("get", url, false);
	req.send(null);
}
function getChildNodesWithoutTextNode(element) {
	var children = new Array();
	for ( var i = 0; i < element.childNodes.length; i++) {
		var child = element.childNodes[i];
		if (child.nodeName == "#text") {
			continue;
		}
		children[children.length] = child;
	}

	return children;
}