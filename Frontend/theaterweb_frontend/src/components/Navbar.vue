<template>
  <v-container fluid class="ma-0 pa-0">
    <!-- thanh menu điều hướng -->
    <!-- elevation để chỉnh bóng -->
    <v-app-bar fluid height="74" :elevation="1">
      <v-col class="item" cols="1"></v-col>
      <v-col class="item" cols="1">
        <a href="/">
          <v-img
            height="100%"
            src="https://betacinemas.vn/Assets/Common/logo/logo.png"
          ></v-img>
        </a>
      </v-col>
      <v-col class="item" cols="2">CÁC RẠP</v-col>
      <v-col class="item d-flex align-center" cols="7">
        <v-toolbar-title height="74">
          <a
            :href="item.route"
            class="px-4 font-oswald navbar-item item"
            v-for="item in menuItems"
            :key="item.title"
          >
            {{ item.title }}
          </a>
        </v-toolbar-title>
      </v-col>
      <v-col class="item" cols="1"></v-col>
    </v-app-bar>
  </v-container>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      menuItems: [
        { title: "LỊCH CHIẾU THEO RẠP", route: "/lich-chieu-theo-rap" },
        { title: "PHIM", route: "/phim" },
        { title: "RẠP", route: "/thong-tin-rap" },
        { title: "GIÁ VÉ", route: "/gia-ve" },
        { title: "TIN MỚI VÀ ƯU ĐÃI", route: "/tin-moi-va-uu-dai" },
        { title: "NHƯỢNG QUYỀN", route: "/nhuong-quyen" },
        { title: "THÀNH VIÊN", route: "/login" },
      ],
    };
  },
};
</script>

<style scoped>
.font-oswald {
  font-family: "Oswald", sans-serif;
  font-weight: 700;
  font-size: 18px;
}
.item {
  height: 74px;
}
.navbar-item {
  text-decoration: none;
  color: black;
}
.navbar-item:hover {
  color: #337ab7;
}
</style>
