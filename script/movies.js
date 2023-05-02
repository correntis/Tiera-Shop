let table = (arr_tag, arr) => {
  let i = 0;
  for (const elem_arr of arr_tag) {
    arr[i++] = elem_arr.textContent;
  }
  return arr;
}

let parse = (xmlString => {
  const parser = new DOMParser();
  const xmlDoc = parser.parseFromString(xmlString, 'text/xml');

  const names = xmlDoc.getElementsByTagName('name');
  const prices = xmlDoc.getElementsByTagName('price');
  const photos = xmlDoc.getElementsByTagName('image');
  const refs = xmlDoc.getElementsByTagName('ref');


  let names_arr = [], prices_arr = [],photos_arr = [],refs_arr =[];
  names_arr = table(names, names_arr);
  prices_arr = table(prices, prices_arr);
  photos_arr = table(photos, photos_arr);
  refs_arr = table(refs,refs_arr);


  let namePar = document.querySelectorAll('.name');
  let pricePar = document.querySelectorAll('.price');
  let photosDiv = document.querySelectorAll('.el');
  let a = document.querySelectorAll('.ref');

  for (let i = 0; i < names_arr.length; i++) {

    namePar[i].innerHTML = `${names_arr[i]}`
    pricePar[i].innerHTML = `${prices_arr[i]}`
    photosDiv[i].style.background = `url('${photos_arr[i]}')`;
    photosDiv[i].style.backgroundSize = 'cover';
    a[i].href = `${refs_arr[i]}`;
  }
})

async function parseXML() {
  let a = await fetch('../XML/gallery.xml');
  let xmlString = await a.text();
  parse(xmlString);
}

parseXML();