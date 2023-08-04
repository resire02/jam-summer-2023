const form = document.getElementById("event-form");

const gT = document.getElementById("goodTechnology");
const gS = document.getElementById("goodStability");
const gEx = document.getElementById("goodExploration");
const gEn = document.getElementById("goodEnlightenment");
const gA = document.getElementById("goodAbundance");

const bT = document.getElementById("badTechnology");
const bS = document.getElementById("badStability");
const bEx = document.getElementById("badExploration");
const bEn = document.getElementById("badEnlightenment");
const bA = document.getElementById("badAbundance");

const chance = document.getElementById("chance");
const id = document.getElementById("eventID");

const title = document.getElementById("title");
const desc = document.getElementById("description");
const cG = document.getElementById("contextGood");
const cB = document.getElementById("contextBad");
const age = document.getElementById("age");

const result = document.getElementById("result");

form.onsubmit = e => {
    console.log(desc.value);
    result.value = GenerateJson().replace('\n','');
    e.preventDefault();
}

function GenerateJson()
{
    return `{"goodTechnology":"${gT.value}","goodStability":"${gS.value}","goodExploration":"${gEx.value}","goodEnlightenment":"${gEn.value}","goodAbundance":"${gA.value}","badTechnology":"${bT.value}","badStability":"${bS.value}","badExploration":"${bEx.value}","badEnlightenment":"${bEn.value}","badAbundance":"${bA.value}","chance":"${chance.value}","eventID":"${id.value}","title":"${title.value}","description":"${desc.value}","contextGood":"${cG.value}","contextBad":"${cB.value}","age":"${age.value}"}`;
}
