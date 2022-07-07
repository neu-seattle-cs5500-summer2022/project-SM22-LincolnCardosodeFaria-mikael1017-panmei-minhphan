import axios from "axios";

class GymDataService {
    findDiet(id) {
        return axios.get(`https://gymmanagement.cropfix.ca/Diet/GetAllDietsByUser?userId=${id}`);
    }
}

export default new GymDataService();