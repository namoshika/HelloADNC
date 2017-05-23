/// <reference path="../types/googlemap.d.ts" />

interface ICountryInfo {
    name: string
    capitalName: string
    description: string
    location: { latitude: number, longitude: number }
}
class MapComponent {
    constructor(elementId: string) {
        this.maker = null
        this.map = new google.maps.Map(
            document.querySelector(elementId),
            {
                zoom: 6,
                center: new google.maps.LatLng(0, 0),
                mapTypeId: google.maps.MapTypeId.ROADMAP
            });
    }
    private map: google.maps.Map
    private maker: google.maps.Marker

    setMarker(country: ICountryInfo) {
        if (this.maker !== null) {
            this.maker.setMap(null);
        }
        let latlng = new google.maps.LatLng(
            country.location.latitude,
            country.location.longitude);
        this.map.setCenter(latlng);
        this.maker = new google.maps.Marker({
            position: latlng,
            map: this.map,
            title: country.capitalName
        });
    };
}
class DescComponent {
    constructor(descId: string) {
        this.descElement = document.querySelector(descId) as HTMLParagraphElement
    }
    private descElement: HTMLParagraphElement
    setDescription(country: ICountryInfo) {
        this.descElement.textContent = country.description;
    }
}
class MenuComponent {
    constructor(selectorId: string) {
        this.selectorElement = document.querySelector(selectorId) as HTMLSelectElement
        this.selectorElement.addEventListener("change", () => {
            let item = this.items[this.selectorElement.selectedIndex];
            this.onChanged(item)
        }, false);
    }
    private items: ICountryInfo[]
    private selectorElement: HTMLSelectElement

    init(items: ICountryInfo[]): void {
        this.items = items
        let eles = items.map((item, idx) => {
            let eleNd = document.createElement("option");
            eleNd.textContent = item.name
            return eleNd
        })
        for (let item of eles) {
            this.selectorElement.appendChild(item);
        }
        this.onChanged(this.items[0])
    }
    onChanged: (item: ICountryInfo) => void
}
(async function main() {
    let tasks = await Promise.all([
        new Promise(resolve => (window.addEventListener("DOMContentLoaded", resolve, false))),
        fetch("js/data.json").then(response => response.json() as Promise<{ countries: ICountryInfo[] }>)
    ])
    let data = tasks[1]
    let mnu = new MenuComponent("#countryNameSelector");
    let map = new MapComponent("#map_canvas");
    let dsc = new DescComponent("#description");
    mnu.onChanged = country => {
        map.setMarker(country);
        dsc.setDescription(country);
    }
    mnu.init(data.countries)
})()