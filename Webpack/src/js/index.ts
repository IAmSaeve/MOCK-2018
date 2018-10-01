let buttonElement: HTMLButtonElement = document.getElementById("calc") as HTMLButtonElement;
let carType: HTMLSelectElement = document.getElementById("Type") as HTMLSelectElement;
let price: HTMLInputElement = document.getElementById("Price") as HTMLInputElement;
let result: HTMLParagraphElement = document.getElementById("Result") as HTMLParagraphElement;

buttonElement.addEventListener("click",
    () => {
        if (carType.value === "Bil") {
            if (price.valueAsNumber <= 200000) {
                result.innerText = "Bil afgift: " + (price.valueAsNumber * 0.85).toString();
            } else {
                result.innerText = "Bil afgift: " + ((price.valueAsNumber * 1.50) - 130000).toString();
            }
        } else {
            if (price.valueAsNumber <= 200000) {
                result.innerText = "Bil afgift: " + ((price.valueAsNumber * 0.85) * 0.20).toString();
            } else {
                result.innerText = "Bil afgift: " + (((price.valueAsNumber * 1.50) - 130000) * 0.20).toString();
            }
        }
});
