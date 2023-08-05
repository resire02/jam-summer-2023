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

let importingJSON = false;
const jsonFilesTextarea = document.getElementById("json-files");

form.onsubmit = e => {
    console.log(desc.value);
    importingJSON = false; // Reset the flag before generating JSON
    const jsonData = GenerateJson().replace('\n','');
    result.value = jsonData;
    addJSONToTextArea(jsonData);
    e.preventDefault();
}

function populateFromJson() {
    const jsonInput = document.getElementById("json-input");
    const jsonData = jsonInput.value.trim();
    if (jsonData) {
        try {
            importingJSON = true; // Set the flag to true before adding the JSON data to form fields
            const jsonFormats = jsonData.split('\n');
            jsonFormats.forEach(json => {
                const formattedJson = json.trim();
                if (formattedJson) {
                    parseAndPopulate(formattedJson);
                    // Add each imported JSON to the textarea (no duplicates)
                    if (!jsonFilesTextarea.value.includes(formattedJson)) {
                        addJSONToTextArea(formattedJson);
                    }
                }
            });
        } catch (error) {
            console.error("Invalid JSON format:", error);
        }
    }
}

function parseAndPopulate(json) {
    try {
        const data = JSON.parse(json);
        gT.value = data.goodTechnology;
        gS.value = data.goodStability;
        gEx.value = data.goodExploration;
        gEn.value = data.goodEnlightenment;
        gA.value = data.goodAbundance;
        bT.value = data.badTechnology;
        bS.value = data.badStability;
        bEx.value = data.badExploration;
        bEn.value = data.badEnlightenment;
        bA.value = data.badAbundance;
        chance.value = data.chance;
        id.value = data.eventID;
        title.value = data.title;
        desc.value = data.description;
        cG.value = data.contextGood;
        cB.value = data.contextBad;
        age.value = data.age;
    } catch (error) {
        console.error("Invalid JSON format:", error);
    }
}

function GenerateJson()
{
    return `{"goodTechnology":"${gT.value}","goodStability":"${gS.value}","goodExploration":"${gEx.value}","goodEnlightenment":"${gEn.value}","goodAbundance":"${gA.value}","badTechnology":"${bT.value}","badStability":"${bS.value}","badExploration":"${bEx.value}","badEnlightenment":"${bEn.value}","badAbundance":"${bA.value}","chance":"${chance.value}","eventID":"${id.value}","title":"${title.value}","description":"${desc.value}","contextGood":"${cG.value}","contextBad":"${cB.value}","age":"${age.value}"}`;
}

function addJSONToTextArea(jsonData) {
    const jsonFilesTextarea = document.getElementById("json-files");
    const existingData = jsonFilesTextarea.value;
    if (!existingData.includes(jsonData)) {
        jsonFilesTextarea.value += jsonData + '\n';
    }
}