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
    const jsonData = GenerateJson().replace(/\n/g, ''); // Replace all newlines
    result.value = jsonData;

    // Determine the age and add JSON to the corresponding textarea
    const ageSelect = document.getElementById("age");
    const selectedAge = ageSelect.value; // Get the selected age value

    if (selectedAge === "1") {
        addToPrehistoric(jsonData);
    } else if (selectedAge === "2") {
        addToCivilization(jsonData);
    } else if (selectedAge === "3") {
        addToMedieval(jsonData);
    } else if (selectedAge === "4") {
        addToColonial(jsonData);
    } else if (selectedAge === "5") {
        addToIndustrial(jsonData);
    } else if (selectedAge === "6") {
        addToInformation(jsonData);
    } else if (selectedAge === "7") {
        addToSpace(jsonData);
    } else if (selectedAge === "8") {
        addToGalactic(jsonData);
    } else if (selectedAge === "9") {
        addToCosmic(jsonData);
    }

    e.preventDefault();
};

function addToPrehistoric(jsonData) {
    addJSONToTextArea(jsonData, "prehistoric-events");
}

function addToCivilization(jsonData) {
    addJSONToTextArea(jsonData, "civilization-events");
}

function addToMedieval(jsonData) {
    addJSONToTextArea(jsonData, "medieval-events");
}

function addToColonial(jsonData) {
    addJSONToTextArea(jsonData, "colonial-events");
}

function addToIndustrial(jsonData) {
    addJSONToTextArea(jsonData, "industrial-events");
}

function addToInformation(jsonData) {
    addJSONToTextArea(jsonData, "information-events");
}

function addToSpace(jsonData) {
    addJSONToTextArea(jsonData, "space-events");
}

function addToGalactic(jsonData) {
    addJSONToTextArea(jsonData, "galactic-events");
}

function addToCosmic(jsonData) {
    addJSONToTextArea(jsonData, "cosmic-events");
}

function addJSONToTextArea(jsonData, textareaId) {
    const textarea = document.getElementById(textareaId);
    const existingData = textarea.value.trim();
    if (!existingData.includes(jsonData)) {
        textarea.value += jsonData + '\n';
    }
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
                    // Add each imported JSON to the corresponding textarea (no duplicates)
                    addToCorrespondingTextarea(formattedJson);
                }
            });
        } catch (error) {
            console.error("Invalid JSON format:", error);
        }
    }
}

function addToCorrespondingTextarea(jsonData) {
    const ageSelect = document.getElementById("age");
    const selectedAge = ageSelect.value; // Get the selected age value

    if (selectedAge === "1") {
        addJSONToTextArea(jsonData, "prehistoric-events");
    } else if (selectedAge === "2") {
        addJSONToTextArea(jsonData, "civilization-events");
    } else if (selectedAge === "3") {
        addJSONToTextArea(jsonData, "medieval-events");
    } else if (selectedAge === "4") {
        addJSONToTextArea(jsonData, "colonial-events");
    } else if (selectedAge === "5") {
        addJSONToTextArea(jsonData, "industrial-events");
    } else if (selectedAge === "6") {
        addJSONToTextArea(jsonData, "information-events");
    } else if (selectedAge === "7") {
        addJSONToTextArea(jsonData, "space-events");
    } else if (selectedAge === "8") {
        addJSONToTextArea(jsonData, "galactic-events");
    } else if (selectedAge === "9") {
        addJSONToTextArea(jsonData, "cosmic-events");
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

function GenerateJson() {
    return `{"goodTechnology":"${gT.value}","goodStability":"${gS.value}","goodExploration":"${gEx.value}","goodEnlightenment":"${gEn.value}","goodAbundance":"${gA.value}","badTechnology":"${bT.value}","badStability":"${bS.value}","badExploration":"${bEx.value}","badEnlightenment":"${bEn.value}","badAbundance":"${bA.value}","chance":"${chance.value}","eventID":"${id.value}","title":"${title.value}","description":"${desc.value}","contextGood":"${cG.value}","contextBad":"${cB.value}","age":"${age.value}"}`;
}

function exportJSON() {
    const prehistoricData = document.getElementById("prehistoric-events").value.trim();
    const civilizationData = document.getElementById("civilization-events").value.trim();
    const medievalData = document.getElementById("medieval-events").value.trim();
    const colonialData = document.getElementById("colonial-events").value.trim();
    const industrialData = document.getElementById("industrial-events").value.trim();
    const informationData = document.getElementById("information-events").value.trim();
    const spaceData = document.getElementById("space-events").value.trim();
    const galacticData = document.getElementById("galactic-events").value.trim();
    const cosmicData = document.getElementById("cosmic-events").value.trim();

    let exportedData = "";

    if (prehistoricData !== "") {
        exportedData += "Prehistoric Events:\n" + prehistoricData + "\n\n";
    }

    if (civilizationData !== "") {
        exportedData += "Civilization Events:\n" + civilizationData + "\n\n";
    }

    if (medievalData !== "") {
        exportedData += "Medieval Events:\n" + medievalData + "\n\n";
    }

    if (colonialData !== "") {
        exportedData += "Colonial Events:\n" + colonialData + "\n\n";
    }

    if (industrialData !== "") {
        exportedData += "Industrial Events:\n" + industrialData + "\n\n";
    }

    if (informationData !== "") {
        exportedData += "Information Events:\n" + informationData + "\n\n";
    }

    if (spaceData !== "") {
        exportedData += "Space Events:\n" + spaceData + "\n\n";
    }

    if (galacticData !== "") {
        exportedData += "Galactic Events:\n" + galacticData + "\n\n";
    }

    if (cosmicData !== "") {
        exportedData += "Cosmic Events:\n" + cosmicData + "\n\n";
    }

    const blob = new Blob([exportedData], { type: "text/plain;charset=utf-8" });
    const url = URL.createObjectURL(blob);

    const a = document.createElement("a");
    a.style.display = "none";
    a.href = url;
    a.download = "RandomEvent.txt";
    document.body.appendChild(a);
    a.click();

    // Remove the temporary URL and element
    window.URL.revokeObjectURL(url);
    document.body.removeChild(a);
}
