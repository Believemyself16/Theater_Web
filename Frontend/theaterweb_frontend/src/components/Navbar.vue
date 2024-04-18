<template>
  <div>
    <!-- thanh menu điều hướng -->
    <v-toolbar app height="74">
      <a href="/">
        <v-img src="https://betacinemas.vn/Assets/Common/logo/logo.png"></v-img>
      </a>
      <v-toolbar-items>
        <v-btn
          class="font-oswald"
          v-for="item in menuItems"
          :key="item.title"
          router
          :to="item.route"
        >
          {{ item.title }}
        </v-btn>
      </v-toolbar-items>
    </v-toolbar>
  </div>
</template>

<script>
export default {
  name: "Navbar",
  data() {
    return {
      menuItems: [
        { title: "Lịch chiếu theo rạp", route: "/lich-chieu-theo-rap" },
        { title: "Phim", route: "/phim" },
        { title: "Rạp", route: "/thong-tin-rap" },
        { title: "Giá vé", route: "/gia-ve" },
        { title: "Tin mới và ưu đãi", route: "/tin-moi-va-uu-dai" },
        { title: "Nhượng quyền", route: "/nhuong-quyen" },
        { title: "Thành viên", route: "/login" },
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
</style>
