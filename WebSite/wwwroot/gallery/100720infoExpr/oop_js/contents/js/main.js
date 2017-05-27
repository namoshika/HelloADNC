/// <reference path="../types/googlemap.d.ts" />
var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : new P(function (resolve) { resolve(result.value); }).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class MapComponent {
    constructor(elementId) {
        this.maker = null;
        this.map = new google.maps.Map(document.querySelector(elementId), {
            zoom: 6,
            center: new google.maps.LatLng(0, 0),
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });
    }
    setMarker(country) {
        if (this.maker !== null) {
            this.maker.setMap(null);
        }
        let latlng = new google.maps.LatLng(country.location.latitude, country.location.longitude);
        this.map.setCenter(latlng);
        this.maker = new google.maps.Marker({
            position: latlng,
            map: this.map,
            title: country.capitalName
        });
    }
    ;
}
class DescComponent {
    constructor(descId) {
        this.descElement = document.querySelector(descId);
    }
    setDescription(country) {
        this.descElement.textContent = country.description;
    }
}
class MenuComponent {
    constructor(selectorId) {
        this.selectorElement = document.querySelector(selectorId);
        this.selectorElement.addEventListener("change", () => {
            let item = this.items[this.selectorElement.selectedIndex];
            this.onChanged(item);
        }, false);
    }
    init(items) {
        this.items = items;
        let eles = items.map((item, idx) => {
            let eleNd = document.createElement("option");
            eleNd.textContent = item.name;
            return eleNd;
        });
        for (let item of eles) {
            this.selectorElement.appendChild(item);
        }
        this.onChanged(this.items[0]);
    }
}
(function main() {
    return __awaiter(this, void 0, void 0, function* () {
        let tasks = yield Promise.all([
            new Promise(resolve => (window.addEventListener("DOMContentLoaded", resolve, false))),
            fetch("js/data.json").then(response => response.json())
        ]);
        let data = tasks[1];
        let mnu = new MenuComponent("#countryNameSelector");
        let map = new MapComponent("#map_canvas");
        let dsc = new DescComponent("#description");
        mnu.onChanged = country => {
            map.setMarker(country);
            dsc.setDescription(country);
        };
        mnu.init(data.countries);
    });
})();
//# sourceMappingURL=main.js.map