<template>
  <v-container>
    <v-row>
      <v-col cols="2">
        <a href="/">
          <v-img
            src="https://betacinemas.vn/Assets/Common/logo/logo.png"
          ></v-img>
        </a>
        <ul class="font-oswald custom-list-style-type">
          <li class="my-1" v-for="item in about" :key="item.tab">
            <a :href="item.route">
              <v-icon>mdi-chevron-right</v-icon>
              {{ item.tab }}
            </a>
          </li>
        </ul>
      </v-col>
      <v-col cols="6">hhi</v-col>
      <v-col cols="2">hi</v-col>
      <v-col cols="2">hi</v-col>
    </v-row>
  </v-container>
</template>

<script>
export default {
  name: "Footer",
  data() {
    return {
      about: [
        { tab: "Giới thiệu", route: "" },
        { tab: "Tuyển dụng", route: "" },
        { tab: "Liên hệ", route: "" },
        { tab: "F.A.Q", route: "" },
        { tab: "Hoạt động xã hội", route: "" },
        { tab: "Điều khoản sử dụng", route: "" },
        { tab: "Chính sách thanh toán, đổi trả - hoàn vé", route: "" },
        { tab: "Liên hệ quảng cáo", route: "" },
        { tab: "Điều khoản bảo mật", route: "" },
        { tab: "Hướng dẫn đặt vé online", route: "" },
      ],
    };
  },
};
</script>

<style scoped>
.font-oswald {
  font-family: "Oswald", sans-serif;
  font-size: 14px;
}
.custom-list-style-type {
  list-style: none;
}
a {
  text-decoration: none;
  color: black;
}
a:hover {
  text-decoration: underline;
  color: #337ab7;
}
</style>
