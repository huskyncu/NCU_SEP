
import { UpdateType, ListViewerManager } from "./core/ListManager";

import './index.scss';
import { FilterSystem } from "./core/FilterSystem";
import { DisplayRangeSystem } from "./core/DisplayRangeSystem";
import { SortSystem } from "./core/SortSystem";
import { DataBaseSystem } from "./core/DataBaseSystem";

import Notify from 'simple-notify'
import 'simple-notify/dist/simple-notify.min.css'

const notifyQueue: Notify[] = [];

function pushNotify(msgs: string[]) {
    msgs.reverse();
    for (const notify of notifyQueue) {
        notify.close();
    }
    notifyQueue.splice(0, notifyQueue.length);
    let i = msgs.length;
    for (const msg of msgs) {
        const notify = new Notify({
            status:      'info',
            title:       msg,
            effect:      'slide',
            speed:       (i * 500),
            showIcon:    true,
            autoclose:   true,
            autotimeout: 5000,
            gap:         20,
            distance:    20,
            type:        1,
            position:    'right top'
        });
        notifyQueue.push(notify);
        i -= 1;
    }
}

function pushErrorNotify(msg: string) {
    for (const notify of notifyQueue) {
        notify.close();
    }
    notifyQueue.splice(0, notifyQueue.length);
    const notify = new Notify({
        status:      'error',
        title:       msg,
        effect:      'slide',
        speed:       500,
        showIcon:    true,
        autoclose:   true,
        autotimeout: 2000,
        gap:         20,
        distance:    20,
        type:        1,
        position:    'right top'
    });
    notifyQueue.push(notify);
}

function rerender(system: ListViewerManager) {
    const container = document.getElementById("ItemContainer");
    container.innerHTML = "";

    function generateRow(ISBN: string, title: string, author: string, isHeader: boolean) {
        const displayDiv = document.createElement('div');
        displayDiv.classList.add('item');
        
        const indexDiv = document.createElement('span');
        indexDiv.textContent = ISBN;
        indexDiv.style.minWidth = '180px';
        indexDiv.style.textAlign = 'left';
        indexDiv.style.fontWeight = isHeader ? 'bolder' : 'normal'

        const authorDiv = document.createElement('span');
        authorDiv.textContent = author;
        authorDiv.style.minWidth = 'fit-content';
        authorDiv.style.fontWeight = isHeader ? 'bolder' : 'normal'

        const titleDiv = document.createElement('span');
        titleDiv.innerHTML = title;
        titleDiv.style.minWidth = '280px';
        titleDiv.style.fontWeight = isHeader ? 'bolder' : 'normal'

        displayDiv.append(indexDiv, titleDiv, authorDiv);
        return displayDiv;
    }

    container.append(
        generateRow("ISBN", "Book Title", "Book Author", true),
        generateRow("------------------------", "---------------------------------", "-----------------------", true),
        ...system.generateDisplayItemRow().map((val) => generateRow(val.ISBN, val.title, val.author, false))
    )

    const paddingDiv = document.createElement('div');
    paddingDiv.style.height = '200px'
    container.append(paddingDiv)
}

function uiInitialize(system: ListViewerManager) {
    // Ininitial Delete Event
    const deleteConfirmElement = document.getElementById('DeleteConfirm') as HTMLButtonElement;
    const deleteInputElement = document.getElementById('ISBNInput') as HTMLInputElement;
    deleteConfirmElement.addEventListener('click', async () => {
        try {
            await system.getProcessor<DataBaseSystem>(UpdateType.Data).deleteBook(deleteInputElement.value);
            await system.updateResult(UpdateType.Data);
            rerender(system);
            pushNotify(system.getUpdateMessage());
        }
        catch(e) {
            pushErrorNotify(e);
        }
    });

    // Ininitial Add Event
    const addConfirmElement = document.getElementById('AddConfirm') as HTMLButtonElement;
    const addTitleInputElement = document.getElementById('TitleInput') as HTMLInputElement;
    const addAuthorInputElement = document.getElementById('AuthorInput') as HTMLInputElement;
    addConfirmElement.addEventListener('click', async () => {
        try {
            const title = addTitleInputElement.value;
            const author = addAuthorInputElement.value;
            await system.getProcessor<DataBaseSystem>(UpdateType.Data).addBook(title, author);
            await system.updateResult(UpdateType.Data);
            rerender(system);
            pushNotify(system.getUpdateMessage());
        }
        catch(e) {
            pushErrorNotify(e);
        }
    });
    

    // Ininitial Filter Event
    const filterInputElement = document.getElementById('FilterInput') as HTMLInputElement;
    const filterCaseElement = document.getElementById('FilterCaseIgnore') as HTMLInputElement;
    const filterHandler = async () => {
        system.getProcessor<FilterSystem>(UpdateType.Filter).setFilterWord(filterInputElement.value);
        system.getProcessor<FilterSystem>(UpdateType.Filter).setIgnoreCase(filterCaseElement.checked);
        await system.updateResult(UpdateType.Filter);
        rerender(system);
        pushNotify(system.getUpdateMessage());
    }
    filterInputElement.addEventListener('input', filterHandler);
    filterCaseElement.addEventListener('input', filterHandler);


    // Ininital Range Event
    const rangeFromElemnt = document.getElementById('RangeFrom') as HTMLInputElement;
    const rangeToElemnt = document.getElementById('RangeTo') as HTMLInputElement;
    const rangeHandler = async () => {
        try {
            const valFrom = rangeFromElemnt.value;
            const valTo = rangeToElemnt.value;
            system.getProcessor<DisplayRangeSystem>(UpdateType.Range).setRange(valFrom, valTo);
            await system.updateResult(UpdateType.Range);
            rerender(system);
            pushNotify(system.getUpdateMessage());
        }
        catch(e) {
            pushErrorNotify(e);
        }
    }
    rangeFromElemnt.addEventListener('input', rangeHandler);
    rangeToElemnt.addEventListener('input', rangeHandler);

    // Ininital Sort Event
    const sortSelectElement = document.getElementById('SortSelect') as HTMLSelectElement;
    sortSelectElement.addEventListener('change', async (e) => {
        system.getProcessor<SortSystem>(UpdateType.Sort).setSortType(sortSelectElement.value);
        await system.updateResult(UpdateType.Sort);
        rerender(system);
        pushNotify(system.getUpdateMessage());
    });
}

async function main() {
    const system = new ListViewerManager();
    await system.setUp();

    uiInitialize(system);
    await system.updateResult(UpdateType.Data);
    rerender(system);
}
main();
