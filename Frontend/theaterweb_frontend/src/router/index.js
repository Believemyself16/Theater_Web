import Vue from "vue";
import VueRouter from "vue-router";
import HomePage from "../views/HomePage.vue";
import LichChieuTheoRap from "../views/LichChieuTheoRap.vue";
import Phim from "../views/Phim.vue";
import Rap from "../views/Rap.vue";
import GiaVe from "../views/GiaVe.vue";
import TinMoiVaUuDai from "../views/TinMoiVaUuDai.vue";
import NhuongQuyen from "../views/NhuongQuyen.vue";
import ThanhVien from "../views/ThanhVien.vue";

Vue.use(VueRouter);

const routes = [
  {
    path: "/",
    name: "home-page",
    component: HomePage,
  },
  {
    path: "/lich-chieu",
    name: "lich-chieu",
    component: LichChieuTheoRap,
  },
  {
    path: "/phim",
    name: "phim",
    component: Phim,
  },
  {
    path: "/thong-tin-rap",
    name: "thong-tin-rap",
    component: Rap,
  },
  {
    path: "/gia-ve",
    name: "gia-ve",
    component: GiaVe,
  },
  {
    path: "/tin-moi-va-uu-dai",
    name: "tin-moi-va-uu-dai",
    component: TinMoiVaUuDai,
  },
  {
    path: "/nhuong-quyen",
    name: "nhuong-quyen",
    component: NhuongQuyen,
  },
  {
    path: "/login",
    name: "login",
    component: ThanhVien,
  },
];

const router = new VueRouter({
  mode: "history",
  base: process.env.BASE_URL,
  routes,
});

export default router;
